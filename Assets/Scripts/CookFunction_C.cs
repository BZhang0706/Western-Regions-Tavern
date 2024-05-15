using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CookFunction_C : MonoBehaviour
{
    public MyUIManager uIManager;
    public LevelController levelController;
    public Camera mainCamera;
    public GameObject Level3;
    public GameObject scanner;
    public float _scannerSpeed = 1.5f;
    public float checkRange = 0.1f;
    public Transform[] A_KnifePosition;
    public Transform[] B_KnifePosition;
    public float fullScore = 150f;
    public float failScore = -50f;
    private bool stopLoopBool = false;
    public bool setScoreBool = false;
    float scannerX;
    private bool allow_A_0To1 = true;
    private bool allow_A_1To2 = false;
    private bool allow_A_2To3 = false;
    private bool allow_A_3To4 = false;

    // private bool allow_B_0To1 = false;
    // private bool allow_B_1To2 = false;
    // private bool allow_B_2To3 = false;
    // private bool allow_B_3To4 = false;
    public int maxCookTime = 3;
    private int _cuttentCookTime = 0;
    public float duration = 2.0f;

    public float duration2 = 1.0f;
    public GameObject Start321Obj;
    private bool StartBool = false;
    public GameObject finishCG1;
    public GameObject pressUI1;
    public GameObject pressUI2;
    public GameObject pressUI3;
    public GameObject pressUI4;


    // Start is called before the first frame update
    void Start()
    {
        pressUI4.SetActive(true);
        pressUI1.SetActive(false);
        pressUI2.SetActive(false);
        pressUI3.SetActive(false);

        StartCoroutine(Start321());
        this.StartBool = false;
        // A_KnifePosition = new Transform[5];
        // B_KnifePosition = new Transform[5];
        scanner.transform.position = A_KnifePosition[0].position;
        Level3.SetActive(true);
        setScoreBool = false;
        stopLoopBool = false;
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
            if (!stopLoopBool)
        {
            scannerX = scanner.transform.position.x;
            if (scanner != null)
            {
                if(_cuttentCookTime < maxCookTime){
                CheckSliderPosition();
                float translation = _scannerSpeed * Time.deltaTime;
                if (scanner.transform.position.x < A_KnifePosition[1].position.x && allow_A_0To1)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }

                if (scanner.transform.position.x < A_KnifePosition[2].position.x && allow_A_1To2)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }
                if (scanner.transform.position.x < A_KnifePosition[3].position.x && allow_A_2To3)
                {
                    scanner.transform.Translate(translation, 0, 0);
                }

                if (scanner.transform.position.x < A_KnifePosition[4].position.x && allow_A_3To4)
                {
                    scanner.transform.Translate(translation, 0, 0);

                }
                }
                else if(_cuttentCookTime >= maxCookTime){
                    stopLoopBool = true;
                }
                
            }
        }
        else
        {
            pressUI4.SetActive(false);
            finishCG1.SetActive(true);
            Level3.SetActive(false);
            // levelController.SetLevelActive(4);
        }
        }
        
    }


    void CheckSliderPosition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log(1);
            if (allow_A_0To1 && scanner.transform.position.x < A_KnifePosition[1].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[1].position.x - checkRange)
            {
                allow_A_0To1 = false;
                allow_A_1To2 = true;
                SetScore(fullScore);

            }
            if (allow_A_1To2 && scanner.transform.position.x < A_KnifePosition[2].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[2].position.x - checkRange)
            {
                allow_A_1To2 = false;
                allow_A_2To3 = true;
                SetScore(fullScore);

            }
            if (allow_A_2To3 && scanner.transform.position.x < A_KnifePosition[3].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[3].position.x - checkRange)
            {
                allow_A_2To3 = false;
                allow_A_3To4 = true;
                SetScore(fullScore);

            }
        }
        if (allow_A_3To4 && scanner.transform.position.x < A_KnifePosition[4].position.x + checkRange && scanner.transform.position.x > A_KnifePosition[4].position.x - checkRange)
            {
                allow_A_3To4 = false;
                allow_A_0To1 = true;
                // SetScore(fullScore);
                _cuttentCookTime ++;
                StartCoroutine(WaitForSeconds(duration, () => {ResetScanner(); }));
            }

    }
    void SetScore(float score)
    {
        uIManager.addScore(score);
        // Debug.Log("AddScore_low executed");
    }
    public void ResetScanner()
{
    Debug.Log(1);
     scanner.transform.position = A_KnifePosition[0].position;
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
