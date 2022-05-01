using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFloor :PlaceableObj
{
    SpriteRenderer spriteRenderer;
    public Sprite darkColor;
    public Sprite lightColor;


    private void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        if((position.x+position.y)%2 == 0)
        {
            spriteRenderer.sprite = lightColor;
        }
        else
        {
            spriteRenderer.sprite = darkColor;
        }
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = new Color32(64, 255, 64, 255);
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }
}