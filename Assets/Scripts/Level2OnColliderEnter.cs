using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2OnColliderEnter : MonoBehaviour
{
    public GameObject cookFunction_B;
    private bool canAddCurrentButton = true;

    // Start is called before the first frame update
    private void Start() {
        canAddCurrentButton = true;
    }
    private void OnTriggerEnter(Collider other) {
        // Debug.Log(1);
        if(other.gameObject.tag == "Scanner"){
            if(canAddCurrentButton){
            cookFunction_B.GetComponent<CookFunction_B>()._currentButton++;
            canAddCurrentButton = false;
            }
            cookFunction_B.GetComponent<CookFunction_B>().setScoreBool = true;
        }
    }
    private void OnTriggerExit(Collider other) {
         if(other.gameObject.tag == "Scanner"){
            canAddCurrentButton = true;
            cookFunction_B.GetComponent<CookFunction_B>().setScoreBool = false;
        }
    }

}
