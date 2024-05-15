using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoSave : MonoBehaviour
{
   public void SaveGame()
    {
        SaveLoadManager saveLoadManager = GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>();
        StoryManager storyManager = GameObject.Find("Story Manager").GetComponent<StoryManager>();
        saveLoadManager.SaveToDisk(storyManager.storyProgress);
        saveLoadManager.LoadFromDisk();
    }
}
