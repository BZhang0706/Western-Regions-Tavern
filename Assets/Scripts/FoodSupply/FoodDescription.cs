using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodDescription : MonoBehaviour
{
    public string description;
    public TextMeshProUGUI textField;
    public FoodList foodList;

    void OnMouseDown()
    {
        if (textField == null)
        {
            Debug.LogError($"textField not sign to clickable object.({gameObject.name})");
            return;
        }
        if (gameObject.GetComponent<Collider2D>() != null)
        {
            textField.text = description;
            SetSpriteOutline();
            foodList.updateSelected(gameObject);
        }
    }

    public void SetSpriteOutline() 
    {
        allInOneShaderControl shaderControl = GetComponent<allInOneShaderControl>();
        shaderControl.OutlineEffect();
    }

    public void SetSpriteDefault()
    {
        allInOneShaderControl shaderControl = GetComponent<allInOneShaderControl>();
        shaderControl.DisableEffect();
    }
}
