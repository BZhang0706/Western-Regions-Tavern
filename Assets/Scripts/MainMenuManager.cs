using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject DoorObj;
    public bool doorActiveBool = false;

    public GameObject MenuObj;
    private bool menuActiveBool = false;
    public GameObject dragonObj;
    public bool dragonActiveBool = false;
    public GameObject DialogueBoxObj;
    public GameObject detailSunObj;
    public GameObject detailShaObj;
    public GameObject detailQieObj;
    public GameObject buttonReturnLv1Obj;
    public GameObject buttonReturnLv2Obj;
    public GameObject detailBGObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickDoorButtonObj(){
        doorActiveBool = !doorActiveBool;
        if(!doorActiveBool){
            try{
            DialogueBoxObj.GetComponent<DialogueBox>()._interactable = true;
            }catch{}
        }
        DoorObj.SetActive(doorActiveBool);
    }
    public void OnClickButtonWarehouse(){
        SceneManager.LoadScene(2);
    }
    public void OnClickButtonCanteen(){
        SceneManager.LoadScene(3);
    }
    public void OnClickButtonKitchen(){
        SceneManager.LoadScene(1);
    }
    public void OnClickQuit(){
        //TODO 
    }
    public void OnClickMenu(){
        // menuActiveBool = !menuActiveBool;
        MenuObj.SetActive(true);
    }
    public void OnButtonReturnLv1(){
        MenuObj.SetActive(false);
    }
    public void OnClickButtonDragon(){
        dragonActiveBool = !dragonActiveBool;
        if(!dragonActiveBool){
            try{
            DialogueBoxObj.GetComponent<DialogueBox>()._interactable = true;
            }catch{}
        }
        dragonObj.SetActive(dragonActiveBool);
    }
    public void OnClickButtonDragonForWareHouse(){
        dragonActiveBool = !dragonActiveBool;
        dragonObj.SetActive(dragonActiveBool);
    }
    public void OnClickButtonDetailSun(){
        buttonReturnLv2Obj.SetActive(true);
        detailBGObj.SetActive(true);
        buttonReturnLv1Obj.SetActive(false);
        detailSunObj.SetActive(true);
    }
    public void OnClickButtonDetailSha(){
        buttonReturnLv2Obj.SetActive(true);
        detailBGObj.SetActive(true);
        buttonReturnLv1Obj.SetActive(false);
        detailShaObj.SetActive(true);
    }
    public void OnClickButtonDetailQie(){
        buttonReturnLv2Obj.SetActive(true);
        detailBGObj.SetActive(true);
        buttonReturnLv1Obj.SetActive(false);
        detailQieObj.SetActive(true);
    }
    public void OnClickButtonReturnLevel2(){
        buttonReturnLv1Obj.SetActive(true);
        buttonReturnLv2Obj.SetActive(false);
        
        detailSunObj.SetActive(false);
        detailShaObj.SetActive(false);
        detailQieObj.SetActive(false);
        detailBGObj.SetActive(false);
    }
}
