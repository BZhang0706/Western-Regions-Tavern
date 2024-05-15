using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BBQManager : MonoBehaviour
{
    List<GameObject> BBQList = new List<GameObject>();
    public UnityEvent OnBBQFinshed;
    public GameObject finishCG;

    private void Update()
    {
        if (BBQList.Count == 0) 
        {
            StartCoroutine(OnBBQFinshedEvent());
            Debug.Log("BBQ Finished");
        }


    }
    public void RemoveBBQ(GameObject BBQObject) 
    {
        BBQList.Remove(BBQObject);
    }

    public void AddBBQ(GameObject BBQObject)
    {
        BBQList.Add(BBQObject);
    }

    IEnumerator OnBBQFinshedEvent()
    {
        finishCG.SetActive(true);
        yield return new WaitForSeconds(3);
        OnBBQFinshed.Invoke();
    }
}
