using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMove : MonoBehaviour
{
    public List<Locator> locatorList;
    public int locatorListIndex = 0;
    public List<GameObject> dialogueBox;
    int dialogueListIndex = 0;
    public UnityEvent OnFinished;

    Vector3 targetPosition;
    AnimationCurve animationCurve;
    float targetDuration;

    private void Start()
    {
        foreach (var dialogue in dialogueBox) 
        {
            dialogue.gameObject.SetActive(false);
        }
        MoveToNextPosition();
    }

    void MoveToNextPosition()
    {
        if (locatorListIndex < locatorList.Count)
        {
            targetPosition = locatorList[locatorListIndex].transform.position;
            animationCurve = locatorList[locatorListIndex].movementCurve;
            targetDuration = locatorList[locatorListIndex].moveDuration;
            StartCoroutine(MoveToPosition());
        }
        else 
        {
            OnFinished.Invoke();
            Debug.Log("Finished");
        }

    }

    IEnumerator MoveToPosition()
    {
        Vector3 start = transform.position;
        float currentTime = 0.0f;

        while (currentTime < targetDuration)
        {
            currentTime += Time.deltaTime;
            float fraction = currentTime / targetDuration;
            float curveFraction = animationCurve.Evaluate(fraction);
            transform.position = Vector3.Lerp(start, targetPosition, curveFraction);
            yield return null; // µÈ´ýÏÂÒ»Ö¡
        }
        transform.position = targetPosition;
        OnMoveFinished();
        locatorListIndex++;
    }

    void OnMoveFinished()
    {
        if (locatorList[locatorListIndex].showDialogue)
        {
            ActiveDialogue();
        }

    }
    void ActiveDialogue()
    {
        dialogueBox[dialogueListIndex].SetActive(true);
        dialogueListIndex++;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space)) 
        {
            MoveToNextPosition();
        }
    }
}
