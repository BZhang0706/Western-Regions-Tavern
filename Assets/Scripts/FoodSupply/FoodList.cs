using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodList : MonoBehaviour
{
    public List<GameObject> foods;


    public void updateSelected(GameObject selectedGameobject)
    {
        foreach (var food in foods) 
        {
            if (food != selectedGameobject)
            {
                food.GetComponent<FoodDescription>().SetSpriteDefault();
            }
        }
    }
}
