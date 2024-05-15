using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    [System.Serializable]
    public class Checker
    {
        public RawFood rawFood;
        public bool isDone;
        public float score;
    }

    public string dishName;
    public Sprite dishSprite;

    public List<Checker> recipeCheckerList = new List<Checker>();

    public void CheckIn(RawFood checkInRawFood)
    {
        bool foundMatch = false;  // 设置一个标志来追踪是否找到匹配项

        foreach (Checker checker in recipeCheckerList)
        {
            if (checker.rawFood == checkInRawFood)
            {
                checker.isDone = true;
                foundMatch = true;
                break;
            }

        }
        if (!foundMatch)
        {
            Debug.LogWarning("No match found for: " + checkInRawFood.name);
        }
    }

    public void SubmitDish()
    {
        float totalScore = 0f;

        foreach (Checker checker in recipeCheckerList)
        {
            if (checker.isDone)
            {
                totalScore += checker.score;
            }
        }

        Debug.Log("Total score for dish '" + dishName + "' is: " + totalScore);
    }
}
