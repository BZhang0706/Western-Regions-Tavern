using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEventForDoor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// 所有的场景漫游模块的按钮
    /// </summary>
    // public GameObject SceneButtons;
    public GameObject DialogueBoxObj;
    private bool canSet = true;
    public GameObject mainMenuObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // if (canSet)
        // {
        DialogueBoxObj.GetComponent<DialogueBox>()._interactable = false;
        // canSet = false;
        // }
        //throw new System.NotImplementedException();
        // Debug.Log("111");
        // SceneButtons.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (mainMenuObj.GetComponent<MainMenuManager>().doorActiveBool == false)
        {
            DialogueBoxObj.GetComponent<DialogueBox>()._interactable = true;
        }
        // Debug.Log("222");
        //throw new System.NotImplementedException();
        // SceneButtons.SetActive(false);
    }
}

