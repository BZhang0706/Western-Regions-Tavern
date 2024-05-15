using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverAndNext : MonoBehaviour
{
    public void Recover()
    {
        SaveLoadManager saveLoadManager = GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>();
        saveLoadManager.recoverAndNext = true;
    }
}
