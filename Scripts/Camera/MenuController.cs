using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public RectTransform one;
    public RectTransform two;
    public RectTransform canvas;
    
    void FixedUpdate()
    {
        if(canvas.sizeDelta.x>canvas.sizeDelta.y){
            one.transform.localPosition = new Vector3(-canvas.sizeDelta.x/2, canvas.sizeDelta.y/2, 10);
            two.transform.localPosition = new Vector3(0, canvas.sizeDelta.y/2+1000, 10);
        }else{
            two.transform.localPosition = new Vector3(0, canvas.sizeDelta.y/2, 10);
            one.transform.localPosition = new Vector3(-canvas.sizeDelta.x/2, canvas.sizeDelta.y/2+1000, 10);
        }
    }
}
