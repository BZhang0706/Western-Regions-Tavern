using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    [Header("Chapter")]
    public List<string> chapterList;
    public Dictionary<string,bool> chapterProgressMap = new Dictionary<string, bool>();


    [Header("Saved")]
    [HideInInspector] public string savedLevel;
    [HideInInspector] public Stack<StoryHistory> savedStoryData;
    [HideInInspector] public Dictionary<string, StoryHistory.CharacterData> savedCharacterDatas = new Dictionary<string, StoryHistory.CharacterData>();
    string saveFolderPath;
    string saveFilePath;
    public bool isNewGame = true;
    public bool recoverAndNext = false;
    bool loaded;

    private void Awake()
    {
        // 检查是否已有GameManager实例存在
        if (Instance == null)
        {
            Instance = this; // 如果没有，这个实例就成为了Singleton实例
            DontDestroyOnLoad(gameObject); // 防止加载新场景时销毁
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // 确保只有一个GameManager实例存在
        }

        saveFolderPath = Path.Combine(Application.persistentDataPath, "Saved");
        saveFilePath = Path.Combine(saveFolderPath, "GameSave.json");

        foreach (var chapter in chapterList)
        {
            chapterProgressMap[chapter] = false;
        }
    }


    private void Start()
    {
        LoadFromDisk();
        if (loaded)
        {
            ActiveGameContinue();

        }
    }

    public void SaveToDisk(StoryProgress storyProgress)
    {
        SavedStory saved = new SavedStory();
        //===save story state===
        saved.histories = storyProgress.storyHistories.ToList(); // ��ջת��Ϊ�б�

        //===save level===
        saved.Level = SceneManager.GetActiveScene().name;

        //===CharacterData===
        saved.characterDatas.FromDictionary(storyProgress.characterDatas);

        // ��json�ַ������浽�ļ���
        string json = JsonUtility.ToJson(saved);
        Directory.CreateDirectory(saveFolderPath);

        System.IO.File.WriteAllText(saveFilePath, json);
        Debug.Log("Story progress saved!");
    }

    public void LoadFromDisk()
    {
        if (System.IO.File.Exists(saveFilePath))
        {
            loaded = true;
            //�����浵
            string json = System.IO.File.ReadAllText(saveFilePath);
            SavedStory saved = JsonUtility.FromJson<SavedStory>(json);
            saved.histories.Reverse();

            //load story state
            savedStoryData = new Stack<StoryHistory>(saved.histories); // ���б�ת����ջ

            //load Character Data
            savedCharacterDatas = saved.characterDatas.ToDictionary();

            //load level
            savedLevel = saved.Level;

            //load progress
            //foreach (var progress in saved.savedchapterProgressMap) 
            //{
            //    chapterProgressMap[progress.Key] = progress.Value;
            //}
            Debug.Log("Story progress loaded from disk");
        }
    }

    void ActiveGameContinue()
    {
        Button continueButton = GameObject.Find("Button_Continus").GetComponent<Button>();
        if (continueButton != null)
        {
            continueButton.interactable = true;
        }
    }
    bool StoryProgressRecovery(bool isrollback = true)
    {
        if (savedLevel == SceneManager.GetActiveScene().name)
        {
            StoryManager storyManager = GameObject.Find("Story Manager").GetComponent<StoryManager>();
            storyManager.storyProgress.storyHistories = SaveLoadManager.Instance.savedStoryData;
            storyManager.storyProgress.characterDatas = SaveLoadManager.Instance.savedCharacterDatas;
            storyManager.storyProgress.LoadState(storyManager.story);
            storyManager.RefreshStory(isrollback);
            return true;
        }
        return false;
    }
    public bool RecoverOnLoad()
    {
        bool isRecover = false;

        if (SceneManager.GetActiveScene().name == savedLevel)
        {
            if (isNewGame == false)
            {
                isNewGame = true;
                StoryProgressRecovery();
                Debug.Log("saved game recoverd to scene,rollback");
                isRecover = true;
            }
            if (recoverAndNext)
            {
                recoverAndNext = false;
                StoryProgressRecovery(false);
                Debug.Log("saved game recoverd to scene,Contonue");
                isRecover = true;
            }
        }
        return isRecover;



    }

    public void LoadSavedLevel()
    {
        isNewGame = false;
        SceneManager.LoadScene(savedLevel);
    }

}
