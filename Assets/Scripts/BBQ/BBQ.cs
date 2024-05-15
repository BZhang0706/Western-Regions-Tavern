using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BBQ : MonoBehaviour
{
    [SerializeField] private BBQManager bbqmanager;

    [SerializeField] private Sprite raw;
    [SerializeField] private Sprite cooked;
    Sprite side1Sprite;
    Sprite side2Sprite;
    SpriteRenderer SpriteRendererRef; 

    [SerializeField] private float timeToCook;
    float _cookTime1;
    float _cookTime2;
    bool cookingSide1 = true;
    bool cook1;
    bool cook2;
    bool finished;

    [SerializeField] private string toFlip;
    [SerializeField] private string notReady;
    [SerializeField] private string cookFinished;
    
    private string textToShow;
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private GameObject textBox;

    bool isHover;

    private void Start()
    {
        bbqmanager.AddBBQ(gameObject);
        SpriteRendererRef = GetComponent<SpriteRenderer>();
        side1Sprite = raw;
        side2Sprite = raw;
        textBox.SetActive(false);
    }




    void Cook1()
    {
        SpriteRendererRef.sprite = side2Sprite;
        SpriteRendererRef.flipX = false;
        if (_cookTime1 < timeToCook)
        {
            _cookTime1 += Time.deltaTime;
            cook1 = false;
        }
        else
        { 
            cook1 = true;
            side1Sprite = cooked;
        }


    }
    void Cook2()
    {
        SpriteRendererRef.sprite = side1Sprite;
        SpriteRendererRef.flipX = true;
        if (_cookTime2 < timeToCook)
        {
            _cookTime2 += Time.deltaTime;
            cook2 = false;
        }
        else
        {
            cook2 = true;
            side2Sprite = cooked;
        }
    }
    private void DetectHover()
    {
        // 将鼠标位置从屏幕空间转换到世界空间
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // 鼠标当前悬停在这个Sprite上
            OnHover();

            if (Input.GetMouseButtonUp(0)) { OnClick(); }
        }
        else
        NotHover();
    }

    private void OnClick() 
    {
        if (finished) 
        {
            bbqmanager.RemoveBBQ(gameObject);
            Destroy(gameObject);
        }
        else cookingSide1 = !cookingSide1;
    }
    private void OnHover()
    {
        if (isHover == false)
        {
            isHover = true;
            textField.text = textToShow;
            textBox.SetActive(true);
        }
    }
    private void NotHover() 
    {
        if (isHover == true)
        {
            isHover = false;
            textField.text = null;
            textBox.SetActive(false);
        }

    }

    private void Update()
    {
        if (cookingSide1 == true)
        {
            Cook1();
            if (cook1 == true)
            {
                if (cook2 == true)
                {
                    textToShow = cookFinished;
                    finished = true;
                }
                else
                textToShow = toFlip;
            }
            else 
            {
                textToShow = notReady;
            }
        }
        if (cookingSide1 == false)
        {
            Cook2();
            if (cook2 == true)
            {
                if (cook1 == true)
                {
                    textToShow = cookFinished;
                    finished = true;
                }
                else
                    textToShow = toFlip;
            }
            else
            {
                textToShow = notReady;
            }
        }

        DetectHover();
    }
}
