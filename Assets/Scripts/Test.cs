using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;


// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class TestUIManager : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject ImageObj;
    public int count;
    public GameObject Button;
    public GameObject child;
    private bool childBool = true;
    public GameObject cameraObj;
    public GameObject AAAObj;
    public GameObject TextObj;
    public bool haveKnifeBool = false;
    public GameObject knifeImageObj;
    public Sprite knifeSprite;
    public bool haveKnife2Bool = false;
    public bool haveKnife3Bool = false;
    public bool haveKnife4Bool = false;
    public bool haveKnife5Bool = false;
    public bool haveKnife6Bool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMoveClick(){
        if(count < 21){
        count ++;
        }
        else if(count == 21){
            UnityEngine.Vector3 position = cameraObj.GetComponent<Camera>().transform.position;  // Vector3 : (1,1,1)
            cameraObj.GetComponent<Camera>().transform.position = new UnityEngine.Vector3(position.x + 25, position.y,position.z);
            
        }
        ImageObj.GetComponent<Image>().sprite = sprites[count];
    }
    public void SetObjActive(){
        childBool = !childBool;
        child.SetActive(childBool);
        // Button.GetComponent<Image>().sprite = null;
    }
    public void SetAAA(){
        AAAObj.SetActive(true);
        TextObj.GetComponent<TMP_Text>().text = "this is a text";
    }
    public void Attack1(){
        haveKnifeBool = true;
        knifeImageObj.GetComponent<Image>().sprite = knifeSprite;
    }
}
