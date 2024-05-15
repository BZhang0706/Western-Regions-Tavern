using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Recipe;

public class CustomerOrder : MonoBehaviour
{
    public DishMenu dishMenu;
    public float patience = 20f;

    [Header("Score")]
    public float scoreGood = 90;
    public float scoreAcceptable = 60;


    public void RandomSelect()
    {
        if (dishMenu.dishList.Count > 0)
        {
            int index = Random.Range(0, dishMenu.dishList.Count); // 随机获取一个索引
            Recipe dish = dishMenu.dishList[index]; // 通过索引获取元素

            Debug.Log("Randomly selected: " + dish.dishName);
        }
        else
        {
            Debug.LogWarning("The list is empty.");
        }
    }

    public void Grading(float score)
    {
        string gradingLevel = "bad";

        if (score < scoreAcceptable)
        {
            gradingLevel = "bad";
        }
        else
        {
            gradingLevel = "acceptable";

        }
        if (score >= scoreGood)
        {
            gradingLevel = "good";
        }

        Debug.Log("Customer Grading = " + gradingLevel);
    }
}
