using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CookFunction_B : MonoBehaviour
{
    public MyUIManager uIManager;
    public LevelController levelController;
    public Camera mainCamera;
    public GameObject Level2;
    public Transform graySliderOriginal;
    public Transform grayCover;
    public Transform grayCoverBackup;
    public GameObject[] grayButton;
    public GameObject[] greenButton;
    public GameObject failedRedButton;
    public int _currentButton;
    [SerializeField]
    private int _failTimeCount;
    public GameObject scanner;
    public float _scannerSpeed = 3.0f;
    public GameObject backgroundSlider;
    public Transform right_Range;
    public float fullScore = 150f;
    public float failScore = -50f;
    private bool stopLoopBool = false;
    public bool setScoreBool = false;
    float scannerX;
    private float grayWidth;
    private float grayMinX;
    private float grayMaxX;
    public float duration = 1.0f;
    public GameObject Start321Obj;
     private bool StartBool = false;
    public GameObject pressUI1;
    public GameObject pressUI2;
    public GameObject pressUI3;
    public GameObject pressUI4;


    // Start is called before the first frame update
    void Start()
    {
        pressUI2.SetActive(true);
        pressUI1.SetActive(false);
        pressUI4.SetActive(false);
        pressUI3.SetActive(false);
        this.StartBool = false;
        StartCoroutine(Start321());
        Level2.SetActive(true);
        setScoreBool = false;
        scanner.transform.position = new Vector3(graySliderOriginal.position.x, -4.28f, -0.4f);
        stopLoopBool = false;
        grayCover.GetComponent<SpriteRenderer>().enabled = false;
        grayWidth = grayCoverBackup.localScale.x * grayCoverBackup.GetComponent<BoxCollider>().size.x;
        grayMinX = grayCoverBackup.position.x - (grayWidth / 2);
        grayMaxX = grayCoverBackup.position.x + (grayWidth / 2);
    }


    // Update is called once per frame
    void Update()
    {
        if(StartBool){
            if (!stopLoopBool)
        {
            scannerX = scanner.transform.position.x;
            ScaleGrayCover();
            if (scanner != null)
            {
                TranslateRight(scanner, _scannerSpeed);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckSliderPosition();
            }
        }
        else
        {
            Level2.SetActive(false);
            levelController.SetLevelActive(1);
        }
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
                stopLoopBool = true;
            }

        }
    }

    void CheckSliderPosition()
    {
        if (setScoreBool)
        {
            if (_currentButton <= grayButton.Length)
            {
                if (_currentButton >= 1)
                {
                    grayButton[_currentButton - 1].GetComponent<SpriteRenderer>().enabled = false;
                    greenButton[_currentButton - 1].GetComponent<SpriteRenderer>().enabled = true;
                    SetScore(fullScore);
                }
            }

        }
        else
        {
            GameObject obj = Instantiate(failedRedButton, new Vector3(scanner.transform.position.x, scanner.transform.position.y, scanner.transform.position.z - 0.3f), scanner.transform.rotation);
            obj.transform.parent = Level2.transform; 
            _failTimeCount++;
            SetScore(failScore);
            uIManager.SetFailCount(_failTimeCount);
        }
    }
    public void ScaleGrayCover()
    {
        if (scannerX >= grayMinX && scannerX <= grayMaxX)
        {
            float newWidth = scannerX - graySliderOriginal.position.x;
            float newWidthInverse = Mathf.InverseLerp(0, grayWidth, newWidth);

            graySliderOriginal.transform.localScale = new Vector3(newWidthInverse, graySliderOriginal.transform.localScale.y, graySliderOriginal.transform.localScale.z);
            grayCover.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    void SetScore(float score)
    {
        uIManager.addScore(score);
        // Debug.Log("AddScore_low executed");
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
