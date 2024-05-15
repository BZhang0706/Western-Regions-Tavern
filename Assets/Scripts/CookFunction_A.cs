using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CookFunction_A : MonoBehaviour
{
    public MyUIManager uIManager;
    public LevelController levelController;
    public GameObject Level1;
    public int _cookTime = 4;
    [SerializeField]
    private int _currentCookTime = 0;
    private bool canAddScore = true;
    private bool canAddFullScore = false;
    // public GameObject[] yellowSlider;
    // public GameObject[] yellowSliderBackup;
    public GameObject[] whiteButton;
    public Transform[] yellowSliderOriginal;
    // public GameObject[] greenSlider;
    // public GameObject[] greenSliderBackup;
    public Transform[] greenSliderOriginal;
    public GameObject grayCover;
    public GameObject grayCoverBackup;
    public Transform graySliderOriginal;
    public GameObject scanner;       // 扫描线
    public float _scannerSpeed = 3.0f;
    public GameObject right_Range;
    public float _range = 10.0f;
    public float _fullScore = 150f;
    public float _lowScore = 50f;
    private float scannerX;
    private float _greenAndYellowWidth;
    private float _greenAndYellowMaxX;
    private float _greenAndYellowMinX;
    private float grayWidth;
    private float grayMinX;
    private float grayMaxX;
    private bool firstTimeHoldSpace = true;
    private bool AllowHoldSpace = true;
    private float firstInverse = 0f;
    public float _checkRange = 0.15f;
    private bool stopLoopBool = false;
    private float newWidth;
    private float newWidthInverse;
    public float duration = 1.0f;
    public GameObject Start321Obj;
    private bool StartBool = false;
    public GameObject pressUI1;
    public GameObject pressUI2;
    public GameObject pressUI3;
    public GameObject pressUI4;


    // Start is called before the first frame update


    //scanner.GetComponent<BoxCollider>().size.x



    // Start is called before the first frame update
    void Start()
    {
        pressUI3.SetActive(true);
        pressUI1.SetActive(false);
        pressUI2.SetActive(false);
        pressUI4.SetActive(false);

        this.StartBool = false;
        StartCoroutine(Start321());
        Level1.SetActive(true);
        stopLoopBool = false;
        grayWidth = grayCoverBackup.transform.localScale.x * grayCoverBackup.GetComponent<BoxCollider>().size.x;
        grayMinX = grayCoverBackup.transform.position.x - (grayWidth / 2);
        grayMaxX = grayCoverBackup.transform.position.x + (grayWidth / 2);
        _currentCookTime = 0;
        ResetCookState();
    }


    // Update is called once per frame
    void Update()
    {
        if(StartBool){
            newWidth = scannerX - yellowSliderOriginal[_currentCookTime].position.x;
        newWidthInverse = Mathf.InverseLerp(0, _greenAndYellowWidth, newWidth);
        if (!stopLoopBool)
        {
            scannerX = scanner.transform.position.x;
            ScaleGrayCover();
            if (scanner != null)
            {
                TranslateRight(scanner, _scannerSpeed);
            }
            if (Input.GetKey(KeyCode.Space) && AllowHoldSpace)
            {
                CheckscannerPosition();
            }

        }
        else
        {
            Level1.SetActive(false);
            levelController.SetLevelActive(3);
        }
        // Debug.Log("ScannerX" + scannerX +  "  grayMinX:" + grayMinX + "  grayMaxX" + grayMaxX + "  _greenAndYellowMinX:" + _greenAndYellowMinX + "  greenMaxX" + _greenAndYellowMaxX);

        }
        

    }
    public void TranslateRight(GameObject obj, float speed)
    {
        if (obj != null)
        {
            float translation = speed * Time.deltaTime;
            obj.transform.Translate(translation, 0, 0);

            // 检查滑块是否到达范围边界
            if (obj.transform.position.x > right_Range.transform.position.x)
            {
                if (_currentCookTime < _cookTime)
                {
                    _currentCookTime++;
                    ResetCookState();
                }
                else
                {
                    stopLoopBool = true;
                }
            }

        }
    }
    void CheckscannerPosition()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AllowHoldSpace = false;
        }
        // Debug.Log("ScannerX" + scannerX +  "  grayMinX:" + grayMinX + "  grayMaxX" + grayMaxX + "  _greenAndYellowMinX:" + _greenAndYellowMinX + "  greenMaxX" + greenMaxX);

        if (scannerX > _greenAndYellowMinX && newWidthInverse > 0 && newWidthInverse < 0.5f)
        {
            if (firstTimeHoldSpace)
            {

                // Debug.Log(newWidth);
                if (newWidth < _checkRange)
                {
                    firstInverse = 0f;
                }
                else
                {
                    firstInverse = Mathf.InverseLerp(0, _greenAndYellowWidth, newWidth);
                    yellowSliderOriginal[_currentCookTime].Translate(newWidth, 0, 0);
                    greenSliderOriginal[_currentCookTime].Translate(newWidth, 0, 0);
                    newWidth = scannerX - yellowSliderOriginal[_currentCookTime].position.x;
                }
                firstTimeHoldSpace = false;
            }
            yellowSliderOriginal[_currentCookTime].localScale = new Vector3(Mathf.Min(newWidthInverse, 1 - firstInverse), yellowSliderOriginal[_currentCookTime].transform.localScale.y, yellowSliderOriginal[_currentCookTime].transform.localScale.z);
            yellowSliderOriginal[_currentCookTime].GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            greenSliderOriginal[_currentCookTime].GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (scannerX < _greenAndYellowMaxX && firstInverse < 0.5f && newWidthInverse > 0.5f && newWidthInverse < 1)
        {
            //scannerX >= (_greenAndYellowMinX + _greenAndYellowMaxX) / 2 &&
            float newWidth = scannerX - greenSliderOriginal[_currentCookTime].position.x;
            float newWidthInverse = Mathf.InverseLerp(0, _greenAndYellowWidth, newWidth);

            greenSliderOriginal[_currentCookTime].localScale = new Vector3(Mathf.Min(newWidthInverse, 1 - firstInverse), greenSliderOriginal[_currentCookTime].transform.localScale.y, greenSliderOriginal[_currentCookTime].transform.localScale.z);

            yellowSliderOriginal[_currentCookTime].GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            greenSliderOriginal[_currentCookTime].GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            if (newWidthInverse > 0.75f)
            {
                canAddFullScore = true;
            }
        }


    }
    public void ScaleGrayCover()
    {
        if (scannerX >= grayMinX && scannerX <= grayMaxX)
        {
            float newWidth = scannerX - graySliderOriginal.transform.position.x;
            float newWidthInverse = Mathf.InverseLerp(0, grayWidth, newWidth);

            graySliderOriginal.transform.localScale = new Vector3(newWidthInverse, graySliderOriginal.transform.localScale.y, graySliderOriginal.transform.localScale.z);
            grayCover.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void ResetCookState()
    {
        if (canAddFullScore)
        {
            AddScore_Full();
        }
        else if (canAddScore && _currentCookTime >= 1)
        {
            AddScore_Low();
        }
        for (int i = 0; i < _cookTime; i++)
        {
            whiteButton[i].SetActive(false);
        }
        whiteButton[_currentCookTime].SetActive(true);
        canAddScore = true;
        canAddFullScore = false;
        firstInverse = 0f;
        firstTimeHoldSpace = true;
        AllowHoldSpace = true;
        firstTimeHoldSpace = true;

        yellowSliderOriginal[_currentCookTime].GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        greenSliderOriginal[_currentCookTime].GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        _greenAndYellowWidth = greenSliderOriginal[_currentCookTime].GetChild(0).transform.localScale.x * yellowSliderOriginal[_currentCookTime].GetChild(0).GetComponent<BoxCollider>().size.x;
        _greenAndYellowMinX = greenSliderOriginal[_currentCookTime].position.x;
        _greenAndYellowMaxX = greenSliderOriginal[_currentCookTime].position.x + _greenAndYellowWidth;
        scanner.transform.position = new Vector3(graySliderOriginal.position.x, -4.28f, -0.4f);

        graySliderOriginal.transform.localScale = new Vector3(0, graySliderOriginal.transform.localScale.y, graySliderOriginal.transform.localScale.z);
        if (_currentCookTime >= 1)
        {
            yellowSliderOriginal[_currentCookTime - 1].transform.localScale = new Vector3(0, yellowSliderOriginal[_currentCookTime].transform.localScale.y, yellowSliderOriginal[_currentCookTime].transform.localScale.z);
            greenSliderOriginal[_currentCookTime - 1].transform.localScale = new Vector3(0, greenSliderOriginal[_currentCookTime].transform.localScale.y, greenSliderOriginal[_currentCookTime].transform.localScale.z);
        }

    }

    void AddScore_Full()
    {
        uIManager.addScore(_fullScore);
    }

    void AddScore_Low()  //TODO : 改成能直接加score，删除_lowScore参数
    {
        uIManager.addScore(_lowScore);
    }
    IEnumerator Start321()
    {
        ChangeNumber(3);
        yield return new WaitForSeconds(duration);

        ChangeNumber(2);
        yield return new WaitForSeconds(duration);
        ChangeNumber(1);
        yield return new WaitForSeconds(duration);

        ChangeNumber(0, "Start!");
        yield return new WaitForSeconds(duration);
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
