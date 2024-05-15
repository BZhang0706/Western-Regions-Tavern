using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
     public float minX = -10.5f; // 这些值应根据你的需求进行调整
    public float maxX = 10.5f;
    public float minY = -10.5f;
    public float maxY = 10.5f;
    private void Update() {
        // Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        // Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        // Debug.Log(cursorPosition);
    }

    void OnMouseDown()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, minX, maxX);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, minY, maxY);
        transform.position = cursorPosition;
    }
    private void OnMouseOver() {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnMouseExit() {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        // 在这里处理放置逻辑
    }
}
