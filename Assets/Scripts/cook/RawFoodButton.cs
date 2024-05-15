using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawFoodButton : MonoBehaviour
{
    public RawFood rawFood;
    public Recipe recipe;
    public Sprite buttonImage;

    private void OnValidate()
    {
        
    }

    public void SendRawFoodState()
    {
        recipe.CheckIn(rawFood);
    }


}
