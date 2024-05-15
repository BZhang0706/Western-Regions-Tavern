using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;
using static StoryHistory.SoundDictionary;
using Febucci.UI.Core;

public class StoryManager : MonoBehaviour
{

    [Header("Story and Characters")]
    [SerializeField] private TextAsset _storyInkJson;
    public Story story;
    public List<Character> cast;
    [SerializeField] private float speakingScale = 1.1f;
    [SerializeField] private float effectTime = 0.2f;
    [SerializeField] [Range(0, 1)] private float Grayscale = 0.9f;
    private Dictionary<string, Expressions> _characterExpressionMap = new Dictionary<string, Expressions>();
    public StoryProgress storyProgress = new StoryProgress();

    [Header("Dialogue Section")]
    [SerializeField] private CanvasGroup _dialogueGroup;
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private TextMeshProUGUI _dialogueTextField;
    [SerializeField] private List<Portrait> _characterSmallPortraits;
    private Dictionary<string, int> _characterSlotMap = new Dictionary<string, int>();    // Mapping of characters to their slots

    [Header("Dialogue Style")]
    [SerializeField] private Animator _dialogueStyleAnimator;
    private Dictionary<string, string> _characterDialogueStyleMap = new Dictionary<string, string>();

    [Header("Options Section")]
    [SerializeField] private CanvasGroup _optionsGroup;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<TextMeshProUGUI> _buttonLabels;

    [Header("Background Section")]
    [SerializeField] private SpriteRenderer _backgroundRenderer;
    [SerializeField] private AnimationCurve fadeInCurve;
    [SerializeField] private AnimationCurve fadeOutCurve;
    [SerializeField] private float fadeInTime = 0.2f;
    [SerializeField] private float fadeOutTime = 0.2f;
    [SerializeField] private CanvasGroup fadeScreen;


    [Header("Sound Section")]
    public AudioSource[] soundTrack;

    [Header("Event Section")]
    public InkEventListener _inkEventListener;


    //the event passes the whole character and the current expression tag for being retrieved and used in different ways
    public UnityEvent<Character, int> OnCharacterChange;

    public static event Action<Story> OnCreateStory;

    private Dictionary<string, string> _tagsCollection;
    private bool _optionsPresented;
    private TypewriterCore typewriter;

    //temp variables to store current tag data
    private StoryHistory currentStoryData;
    private StoryHistory previousStoryData;
    StoryHistory.CharacterData previousCharacterData;
    private Character _currentCharacter;
    private Expressions _currentExpression;
    private int _expressionsIndex;
    private bool isFreshLoad = true;

    [Serializable]
    public class Portrait
    {
        public Image image;
        public bool state;
    }

    //public PlayerInput input;
    void Awake()
    {
        InitStory();
        typewriter = _dialogueTextField.gameObject.GetComponent<TypewriterCore>();
    }

    void InitStory()
    {
        //preparing the JSON from Ink to be used here.
        story = new Story(_storyInkJson.text);
        if (OnCreateStory != null)
            OnCreateStory(story);
        _tagsCollection = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }
    void Start()
    {
        StartCoroutine(FadeIn(fadeInTime));
        HideAllCharacters();

        if (cast == null)
        {
            Debug.LogException(new Exception("Cast list is empty. Please add at least one character to the list"));
        }
        //preparing the dialogue UI for starting the story
        setUIElement(_dialogueGroup, true, false);
        setUIElement(_optionsGroup, false, false);
        //Loading the first story node and showing it
        if (!SaveLoadManager.Instance.RecoverOnLoad())
        {
            RefreshStory();
        }
    }

    //needs to always be called in a if (story.canContinue) check
    public void RefreshStory(bool isRollback = false)
    {
        Debug.Log("RefreshStory");
        string rawText;
        currentStoryData = new StoryHistory();

        if (storyProgress.storyHistories.Any())
             previousStoryData = storyProgress.storyHistories.Peek();
        else previousStoryData = new StoryHistory();

        //Gets the next sentence, trims it from extra spaces and assigns it to the interface
        if (isRollback)
        {
            rawText = story.currentText;

        }
        else
        {
            rawText = story.Continue();

        }
        currentStoryData.text = rawText;

        //gets the tags in format #key:value and stores them in a dictionary
        foreach (string s in story.currentTags)
        {
            //splitting the string in two parts
            string[] keyValues = s.ToLower().Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Log("Key: " + keyValues[0] + " Value: " + keyValues[1]);
            _tagsCollection[keyValues[0]] = keyValues[1];

        }


        //=== character ===
        //here we manage the character tag.
        //first we make sure we have a character key
        if (_tagsCollection.TryGetValue("character", out string characterName))
        {
            
            currentStoryData.character = characterName;
        }
        else
        {
            if (previousStoryData.character  != "default")
            {
                currentStoryData.character = previousStoryData.character;
            }
            else
            {
                currentStoryData.character = cast[0].characterName;
                Debug.LogWarning("Please specify the target Character，fall back to the first character");

            }
        }


        //===finding character history===
        // try get value
        if (!storyProgress.characterDatas.TryGetValue(currentStoryData.character, out previousCharacterData))
        {
            // if no match, create one
            previousCharacterData = new StoryHistory.CharacterData();
            storyProgress.characterDatas[currentStoryData.character] = previousCharacterData;
        }


        //=== Expression ===
        //here we deal with the character's expression, again, taken from the tags
        if (_tagsCollection.TryGetValue("expression",out string expressionName))
        {
            currentStoryData.characterData.expression = expressionName;
            previousCharacterData.expression = expressionName;
        }
        else
        {
            currentStoryData.characterData.expression = previousCharacterData.expression;
        }


        //=== Slot ===
        if (_tagsCollection.TryGetValue("place", out string slotStr) && int.TryParse(slotStr, out int slot))
        {
            currentStoryData.characterData.slotIndex = Math.Max(slot - 1, 0); 
        }
        else
        {
            currentStoryData.characterData.slotIndex = previousCharacterData.slotIndex;
        }


        //=== style ===
        if (_tagsCollection.TryGetValue("style", out string styleValue))
        {
            currentStoryData.characterData.boxStyle = styleValue;
        }
        else
        {
            currentStoryData.characterData.boxStyle = previousCharacterData.boxStyle;
        }


        //=== background ===
        if (_tagsCollection.TryGetValue("background",out string backgroundName))
        {
            currentStoryData.background = backgroundName;
        }
        else
        {
            currentStoryData.background = previousStoryData.background;
        }


        //=== Music ===
        string currentsound;
        int currentSoundTrack;
        if (_tagsCollection.TryGetValue("sound", out string musicName))
        {
            currentsound = musicName;
            //--- SoundTrack ---
            if (_tagsCollection.TryGetValue("track", out string trackStr) && int.TryParse(trackStr, out int track))
            {
                currentSoundTrack = Mathf.Clamp(track - 1, 0, soundTrack.Length - 1); // 确保trackIndex在有效范围内
            }
            else
            {
                currentSoundTrack = 0;
            }
            currentStoryData.soundDictionary = previousStoryData.soundDictionary.DeepCopy();
            currentStoryData.soundDictionary.AddSound(currentSoundTrack, currentsound);
        }
        else
        {
            currentStoryData.soundDictionary = previousStoryData.soundDictionary.DeepCopy();
        }




        //=== Back ===
        if (_tagsCollection.TryGetValue("back", out string backcharacterName))
        {
            BackCharacter(backcharacterName);
        }


        //=== Event ===
        if (_tagsCollection.TryGetValue("event", out string eventName))
        {
            currentStoryData.eventname = eventName;
        }


        //=== State ===
        currentStoryData.storyState = story.state.ToJson();


        //=== Push ===
        storyProgress.storyHistories.Push(currentStoryData);
        storyProgress.characterDatas[currentStoryData.character] = currentStoryData.characterData;
        _tagsCollection.Clear();

        //###Update UI###


        //===Character===
        //Match the name in StoryData with castList
        _currentCharacter = cast.FirstOrDefault(c => string.Equals
                (c.name, currentStoryData.character, StringComparison.OrdinalIgnoreCase));
        // if there is no character with that name, I fall back to the first character
        if (_currentCharacter == null)
        {
            _currentCharacter = cast[0];
            Debug.LogWarning("Target character was not found:" + currentStoryData.character);
        }


        //===Expression===
        //we find the matching expressionindex that we are using for getting the right expression art. If it's not found, it defaults to 0
        _expressionsIndex = _currentCharacter.expressionsList.Select((e, i) => new { e, i }).Where(pair =>
                String.Equals(pair.e.expressionName, currentStoryData.characterData.expression, StringComparison.OrdinalIgnoreCase))
                .Select(pair => pair.i).DefaultIfEmpty(0).FirstOrDefault();
        _currentExpression = _currentCharacter.expressionsList[_expressionsIndex];


        //=== Slot ===
        if (currentStoryData.characterData.slotIndex > _characterSmallPortraits.Count)
        {
            Debug.LogWarning($"Place index {currentStoryData.characterData.slotIndex} out of range for character portraits list {_characterSmallPortraits.Count}. reset to 0");
            currentStoryData.characterData.slotIndex = 0;
        }

        // Clear old slot if moving to a new slot
        if (currentStoryData.characterData.slotIndex != previousCharacterData.slotIndex)
        {
            BackCharacter(currentStoryData.character);
        }


        //=== Art ===
        _characterSmallPortraits[currentStoryData.characterData.slotIndex].image.sprite = _currentExpression.expressionArt;

        //check current solt actvite state
        if (_characterSmallPortraits[currentStoryData.characterData.slotIndex].state == false)
        {
            _characterSmallPortraits[currentStoryData.characterData.slotIndex].state = true;
            PortraitSpeakingEffect(_characterSmallPortraits[currentStoryData.characterData.slotIndex].image);
        }
        // check other solt actvite state
        foreach (Portrait PortraitSlot in _characterSmallPortraits)
        {
            if (PortraitSlot != _characterSmallPortraits[currentStoryData.characterData.slotIndex])
            {
                //如果角色上回合处于说话状态
                if (PortraitSlot.state == true)
                {
                    PortraitSlot.state = false;
                    PortraitNonSpeakingEffect(PortraitSlot.image);
                }
            }
        }


        CanvasGroup canvasGroup = _characterSmallPortraits[currentStoryData.characterData.slotIndex].image.gameObject.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1; // Make the new slot visible
        }
        else
        {
            Debug.LogWarning("character Portrait canvasGroup not found");
        }


        //=== style ===
        int layerIndex = 0;
        int stateHash = Animator.StringToHash(currentStoryData.characterData.boxStyle); // 将状态名称转换为哈希值

        if (!_dialogueStyleAnimator.HasState(layerIndex, stateHash))
        {
            Debug.LogWarning($"dialogueStyle {currentStoryData.characterData.boxStyle} not contain in animator. Reset to default");
            currentStoryData.characterData.boxStyle = "default";
        }

        _dialogueStyleAnimator.Play(currentStoryData.characterData.boxStyle);


        //=== background ===
        
        if (currentStoryData.background != "default")
        {
            if (isFreshLoad)
            {
                SetBackground(currentStoryData.background);
            }
            else 
            {
                if (currentStoryData.background != previousStoryData.background)
                {
                    SetBackground(currentStoryData.background);
                }
            }
        }


        //=== Music ===

        foreach (var soundDataPair in currentStoryData.soundDictionary.soundDataPairs)
        {
            SoundDataPair previousSoundDataPair = previousStoryData.soundDictionary.soundDataPairs.Find(pair => pair.track == soundDataPair.track);
            Debug.Log($"track= {soundDataPair.track}, soundName= {soundDataPair.soundName}");

            if (soundDataPair.soundName != "none")
            {
                if (isFreshLoad)
                {
                    PlayMusic(soundDataPair.soundName, soundDataPair.track);
                }
                else
                {
                    if (previousSoundDataPair == null || soundDataPair.soundName != previousSoundDataPair.soundName)
                    {
                        PlayMusic(soundDataPair.soundName, soundDataPair.track);
                    }
                }
            }
        }
;
        

        //=== Event ===
        if (currentStoryData.eventname != "none")
        {
            _inkEventListener.TriggerEvent(currentStoryData.eventname);
        }

        //=== Text ===
        //The character name
        _characterName.text = _currentCharacter.characterName;
        //here we write the line on screen
        _dialogueTextField.text = rawText;
        isFreshLoad = false;
}

//this is for presenting the options on the premade interface buttons. 
//only up to 4 options are supported.
void PresentOptions()
    {
        _optionsPresented = true;
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (i < story.currentChoices.Count)
            {
                Choice choice = story.currentChoices[i];
                _buttons[i].interactable = true;
                _buttonLabels[i].text = choice.text.Trim();
                _buttons[i].onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
            else
            {
                _buttons[i].interactable = false;
                _buttonLabels[i].text = "";
            }
        }
        setUIElement(_dialogueGroup, false);
        setUIElement(_optionsGroup, true);
    }

    //this is to advance text by clicking anywhere when we are in a dialogue context. 
    //nothing happens if we press a button as buttons have their own behavior
    public void OnClick(InputAction.CallbackContext c)
    {
        if (c.started)
        {
            if (typewriter.isShowingText)
            {
                typewriter.SkipTypewriter();
            }
            else
            {
                if (!_optionsPresented)
                {
                    if (story.canContinue)
                    {
                        RefreshStory();
                    }
                    else if (story.currentChoices.Count > 0)
                    {
                        PresentOptions();
                    }
                }
            }
        }

    }


    //this is what happens when we press an option button
    void OnClickChoiceButton(Choice choice)
    {
        _optionsPresented = false;
        setUIElement(_dialogueGroup, true);
        setUIElement(_optionsGroup, false);
        story.ChooseChoiceIndex(choice.index);
        ClearButtons();
        RefreshStory();

    }

    void ClearButtons()
    {
        foreach (Button b in _buttons)
        {
            b.onClick.RemoveAllListeners();
        }
    }

    void setUIElement(CanvasGroup group, bool active = true, bool fading = true)
    {

        if (fading)
        {
            group.interactable = false;
            group.blocksRaycasts = false;
            StartCoroutine(FadeUI(group, active ? 0 : 1, active ? 1 : 0, active, 0.2f));
        }
        else
        {
            group.alpha = active ? 1 : 0;
            group.interactable = active;
            group.blocksRaycasts = active;
        }

    }

    IEnumerator FadeUI(CanvasGroup group, float from = 0, float to = 1, bool active = true, float time = 0.5f)
    {
        float t = 0;
        while (t <= time)
        {
            group.alpha = Mathf.Lerp(from, to, t / time);
            t += Time.deltaTime;

            yield return null;
        }

        group.alpha = active ? 1 : 0;
        group.interactable = active;
        group.blocksRaycasts = active;

    }

    void HideAllCharacters()
    {
        foreach (var portrait in _characterSmallPortraits)
        {
            CanvasGroup canvasGroup = portrait.image.gameObject.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
            }
        }
    }

    void SetBackground(string backgroundName)
    {
        // 查找与提供的名称匹配的Background ScriptableObject
        Background foundBackground = Resources.Load<Background>($"backgrounds/{backgroundName}");
        if (foundBackground != null && foundBackground.backgroundSprite != null)
        {
            StartCoroutine(FadeOut(foundBackground, fadeOutTime));
        }
        else
        {
            Debug.LogWarning($"Background not found: {backgroundName}");
        }
    }

    void BackCharacter(string backcharacterName)
    {
            int slotIndex = storyProgress.characterDatas[backcharacterName].slotIndex;
            // 清除指定角色的立绘并隐藏CanvasGroup
            _characterSmallPortraits[slotIndex].image.sprite = null;
            CanvasGroup canvasGroup = _characterSmallPortraits[slotIndex].image.gameObject.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
            }
    }

    void PlayMusic(string musicName, int trackIndex)
    {
        SoundClip musicClip = Resources.Load<SoundClip>($"SoundClips/{musicName}");
        if (musicClip != null && trackIndex < soundTrack.Length)
        {
            AudioSource audioSource = soundTrack[trackIndex];
            audioSource.clip = musicClip.clip;
            audioSource.loop = musicClip.loop;
            audioSource.volume = musicClip.volume;
            // TODO: 添加淡入淡出逻辑
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"sound clip not found: {musicName} or track index out of range: {trackIndex}");
        }
    }

    IEnumerator FadeOut(Background background, float duration)
    {
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = fadeOutCurve.Evaluate(currentTime / duration);
            fadeScreen.alpha = alpha;
            yield return null;
        }
        _backgroundRenderer.sprite = background.backgroundSprite;
        StartCoroutine(FadeIn(fadeInTime));
    }

    IEnumerator FadeIn(float duration)
    {
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = fadeInCurve.Evaluate(currentTime / duration);
            fadeScreen.alpha = alpha;
            yield return null;
        }
    }

    IEnumerator LerpImageColor(Image target, Color targetColor, float duration)
    {
        float time = 0;
        Color startColor = target.color;
        while (time < duration)
        {
            target.color = Color.Lerp(startColor, targetColor, time / duration);
            time += Time.deltaTime;
            yield return null; // 等待下一帧
        }
    }

    IEnumerator LerpPortraitTransform(RectTransform target, Vector3 targetVector3, float duration)
    {
        float time = 0;
        Vector3 startVector3 = target.localScale;
        while (time < duration)
        {
            target.localScale =  Vector3.Lerp(startVector3, targetVector3, time / duration);
            time += Time.deltaTime;
            yield return null; // 等待下一帧
        }
    }




    void PortraitSpeakingEffect(Image speakingPortrait)
    {
        RectTransform portraitTransform = speakingPortrait.GetComponent<RectTransform>();
        StartCoroutine(LerpPortraitTransform( portraitTransform, new Vector3(speakingScale, speakingScale, speakingScale), effectTime));
        StartCoroutine(LerpImageColor(speakingPortrait, new Color(1, 1, 1), effectTime));

    }

    void PortraitNonSpeakingEffect(Image speakingPortrait)
    {
        RectTransform portraitTransform = speakingPortrait.GetComponent<RectTransform>();
        StartCoroutine(LerpPortraitTransform(portraitTransform, new Vector3(1, 1, 1), effectTime));
        StartCoroutine(LerpImageColor(speakingPortrait, new Color(Grayscale, Grayscale, Grayscale), effectTime));

    }


    public void RollbackStory()
    {
        if (storyProgress.LoadPreviousState(story))
        {
            //当处于选项界面时
            if (_optionsPresented == true)
            {
                _optionsPresented = false;
                setUIElement(_dialogueGroup, true);
                setUIElement(_optionsGroup, false);
            }
            RefreshStory(
                );

        }
        else
        {
            Debug.Log("已经回到故事开始，不能再后退了");
        }
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B)||Input.GetKeyUp(KeyCode.Backspace))
        { RollbackStory(); }

        if (Input.GetKeyUp(KeyCode.S))
        { SaveLoadManager.Instance.SaveToDisk(storyProgress); }
    }
}
