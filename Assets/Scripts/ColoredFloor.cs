using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFloor :PlaceableObj
{
    SpriteRenderer spriteRenderer;
    public Sprite darkColor;
    public Sprite lightColor;


    protected override void Start()
    {
        base.Start();
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

    protected override void Update()
    {
        
    }


}
