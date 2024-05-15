using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allInOneShaderControl : MonoBehaviour
{
    public Material defaultMat;
    public Material outlineMat;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void DisableEffect()
    {
        spriteRenderer.material = defaultMat;
    }

    public void OutlineEffect() 
    {
        spriteRenderer.material = outlineMat;
    }
}
