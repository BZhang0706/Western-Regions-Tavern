using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public bool changeLevelBool = true;
    public int levelNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetLevelActive(int number){
        switch(number){
            case 0:
            break;
            case 1:
            Level1.SetActive(true);
            changeLevelBool = false;
            break;
            case 2:
            Level2.SetActive(true);
            changeLevelBool = false;
            break;
            case 3:
            Level3.SetActive(true);
            changeLevelBool = false;
            break;
            case 4:
            Level4.SetActive(true);
            changeLevelBool = false;
            break;
            default:
            break;
            
        }
    }
}
