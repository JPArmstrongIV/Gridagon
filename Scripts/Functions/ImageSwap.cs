using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSwap : Func
{
    public UnityEngine.UI.Image target;
    public Sprite[] views;
    public int viewing;
    
    public override void doThing(){
        if(++viewing>=views.Length) viewing=0;
        target.sprite = views[viewing];
    }
    
    public override void offThing(){
    }
}