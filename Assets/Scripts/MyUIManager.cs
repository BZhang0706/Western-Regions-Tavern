using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyUIManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject failCountText;
    public float totalScore = 0f;
    private Color defaultColor = Color.black;
    public float duration2 = 1.0f;
    public GameObject Start321Obj;
    public GameObject menuContent;
    public GameObject QieGaoDetail;
    public int currentMenuLayer;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void showQieGaoDetail(){
        QieGaoDetail.SetActive(true);
        menuContent.SetActive(false);
        currentMenuLayer++;
    }
    public void Return(){
        if(currentMenuLayer == 1){
            QieGaoDetail.SetActive(false);
            menuContent.SetActive(true);
        }
            currentMenuLayer--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(float score, Color? color = null){
        totalScore += score;
        this.scoreText.GetComponent<TMP_Text>().text = "Score : " + totalScore;
        if(color == null){
            color = Color.black;
            this.scoreText.GetComponent<TMP_Text>().color = (Color)color;
        }
        else if(color != null){
            this.scoreText.GetComponent<TMP_Text>().color = (Color)color;
        }
    }
    public void SetFailCount(int count){
        this.failCountText.GetComponent<TMP_Text>().text = "FailCount : " + count;
    }
    public IEnumerator Start321()
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
        // this.StartBool = true;

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
