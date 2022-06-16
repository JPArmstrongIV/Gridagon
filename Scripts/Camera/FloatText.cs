using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
    public GameObject target;
    public Canvas view;
    public Camera cam;
    public float offsetX;
    public float offsetY;
    public float deltaX;
    public float deltaY;
    public float deltaZ;
    public float scaleX;
    public float scaleY;
    public float offsetSX=10;
    public float offsetSY=10;
    public bool sameSize = true;
    
    void Start(){
        if(cam==null){
            cam = Camera.main;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RectTransform rt = view.transform.GetComponent<RectTransform>();
        
        float viewW = rt.sizeDelta.x;
        float viewH = rt.sizeDelta.y;
        
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        
        deltaX = (targetX-cam.transform.position.x)+offsetX;
        deltaY = (targetY-cam.transform.position.y)+offsetY;
        deltaZ = (target.transform.position.z-cam.transform.position.z);
        
        scaleX = offsetSX/Mathf.Abs(deltaZ);
        scaleY = offsetSY/Mathf.Abs(deltaZ);
        
        if(deltaZ>0){
            var frustumHeight = 2.0f * deltaZ * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
            var frustumWidth = frustumHeight * cam.aspect;
            
            transform.localPosition = new Vector3(deltaX/frustumWidth*viewW, deltaY/frustumHeight*viewH, 0);
            
            if(sameSize)GetComponent<RectTransform>().localScale = new Vector3(scaleX, scaleY,1);
        }else transform.localPosition = new Vector3(-1000,-1000,0);
    }
}
