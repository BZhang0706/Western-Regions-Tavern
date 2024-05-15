using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Bowl : MonoBehaviour
{
    public int sceneIndex = 0;
    public MyUIManager uIManager;
    // 使用队列来存储盆中的食材
    [SerializeField]
    private Queue<GameObject> foodInBowl = new Queue<GameObject>();

    // 这里定义了需要的食材组合
    public List<GameObject> requiredFood = new List<GameObject>();
    public float duration2 = 1.0f;
    public GameObject Start321Obj;

   private void OnTriggerEnter(Collider other)
{
    if (other.tag == "InteractableFood")
    {
        // Debug.Log(1);
        foodInBowl.Enqueue(other.gameObject); // 直接将 GameObject 加入队列
        CheckFoodCombination();
    }
}


    private void OnTriggerExit(Collider other)
    {
        // 可以根据需要在食材离开盆时进行处理
    }

    private void CheckFoodCombination()
{
    bool containsAllRequiredFood = requiredFood.All(required => foodInBowl.Contains(required));

    if (containsAllRequiredFood)
    {
        // sceneIndex = 0;
        StartCoroutine(Start321());
    }
    else
    {
        ExecuteFunctionN();
    }
}




    private void ExecuteFunctionN()
    {
        Debug.Log("Not enough required food in the bowl ! ");
    }
    public IEnumerator Start321()
    {
        ChangeNumber(3);
        yield return new WaitForSeconds(duration2);

        ChangeNumber(2);
        yield return new WaitForSeconds(duration2);
        ChangeNumber(1);
        yield return new WaitForSeconds(duration2);

        // ChangeNumber(0, "Start!");
        // yield return new WaitForSeconds(duration2);
        ChangeNumber(0, "  ");
        // this.StartBool = true;

        StopCoroutine(Start321());
        SceneManager.LoadScene(sceneIndex);
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
