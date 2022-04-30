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
        spriteRenderer = GetComponent<SpriteRenderer>();
        if((position.x+position.y)/2 == 0)
        {
            spriteRenderer.sprite = lightColor;
        }
        else
        {
            spriteRenderer.sprite = darkColor;
        }
    
    }

   

}
