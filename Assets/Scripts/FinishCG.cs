using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FinishCG : MonoBehaviour
{
    public GameObject Start321Obj;
    private bool StartBool = false;
    public float duration2 = 1.0f;
    public UnityEvent OnFinishEvent;
    public string OnfinishedLoadLevel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start321());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return new WaitForSeconds(duration2);

        OnFinishEvent.Invoke();

        SceneManager.LoadScene(OnfinishedLoadLevel);

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
