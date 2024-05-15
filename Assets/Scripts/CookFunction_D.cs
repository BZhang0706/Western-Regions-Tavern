using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CookFunction_D : MonoBehaviour
{
    public MyUIManager uIManager;
    public LevelController levelController;
    public GameObject Level4;
    public float fullScore = 150f;
    public float failScore = -50f;
    public bool setScoreBool = false;
    public Transform colorfulSliderOrigin;
    public Transform colorfulSliderOriginBackup;
    public int maxCookTime = 2;
    [SerializeField]
    private int _cuttentCookTime = 0;
    public float duration = 2.0f;
    public float width = 0.1f;
    private int fallStart = 0;
    public float fallWidth = 0.05f;
    public float duration2 = 1.0f;
    public GameObject Start321Obj;
    private bool StartBool = false;
    public GameObject pressUI1;
    public GameObject pressUI2;
    public GameObject pressUI3;
    public GameObject pressUI4;


    // Start is called before the first frame update
    void Start()
    {
        pressUI1.SetActive(true);
        pressUI3.SetActive(false);
        pressUI2.SetActive(false);
        pressUI4.SetActive(false);
        this.StartBool = false;
        StartCoroutine(Start321());
        colorfulSliderOriginBackup.gameObject.SetActive(false);
        colorfulSliderOrigin.localScale = new Vector3(colorfulSliderOrigin.localScale.x, 0.0f, colorfulSliderOrigin.localScale.z);
        Level4.SetActive(true);
        setScoreBool = false;
    }
    public static IEnumerator WaitForSeconds(float duration, Action action)
    {
        yield return new WaitForSeconds(duration);
        action?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        if(StartBool){
             if (_cuttentCookTime < maxCookTime)
        {
            CheckSliderPosition();
            FallDown();
        }
        else
        {
        Level4.SetActive(false);
        // levelController.changeLevelBool = true;
        levelController.SetLevelActive(2);
        }
        }
       
    }


    void CheckSliderPosition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (colorfulSliderOrigin.localScale.y < 1f)
            {
                colorfulSliderOrigin.localScale = new Vector3(colorfulSliderOrigin.localScale.x, colorfulSliderOrigin.localScale.y + width, colorfulSliderOrigin.localScale.z);
            }
        }
        if(colorfulSliderOrigin.localScale.y >= 0.8f){
            if(!setScoreBool){
            SetScore(fullScore);
            setScoreBool = true;
            }
        }
        if (colorfulSliderOrigin.localScale.y >= 1f)
        {
            colorfulSliderOrigin.localScale = new Vector3(colorfulSliderOrigin.localScale.x, 0.0f, colorfulSliderOrigin.localScale.z);
            colorfulSliderOriginBackup.gameObject.SetActive(true);
            StartCoroutine(WaitForSeconds(duration, () => { ResetSlider(); }));
        }

    }
    public void FallDown(){
        if(colorfulSliderOrigin.localScale.y >= 0f){
        colorfulSliderOrigin.localScale = new Vector3(colorfulSliderOrigin.localScale.x, colorfulSliderOrigin.localScale.y - fallWidth * Time.deltaTime, colorfulSliderOrigin.localScale.z);
        }
    }
    void SetScore(float score)
    {
        uIManager.addScore(score);
        // Debug.Log("AddScore_low executed");
    }
    public void ResetSlider()
    {
        colorfulSliderOriginBackup.gameObject.SetActive(false);
        _cuttentCookTime++;
        setScoreBool = false;
    }
    IEnumerator Start321()
    {
        ChangeNumber(3);
        yield return new WaitForSeconds(duration2);

        ChangeNumber(2);
        yield return new WaitForSeconds(duration2);
        ChangeNumber(1);
        yield return new WaitForSeconds(duration2);

        ChangeNumber(0, "Start!");
        yield return new WaitForSeconds(duration2);
        ChangeNumber(0, "  ");
        this.StartBool = true;

        StopCoroutine(Start321());
    }

    private void ChangeNumber(int number, string start = null)
    {
        // Debug.Log(number);
        if (number != 0)
        {
            Start321Obj.GetComponent<TMP_Text>().text = "   " + number.ToString();
        }
        else if (start != null)
        {
            Start321Obj.GetComponent<TMP_Text>().text = start;
        }
    }
}
