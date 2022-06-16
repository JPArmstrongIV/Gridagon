using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ = 0;
    public float zoomOutMin = 1;
    public float zoomOutBase = 5;
    public float zoomOutMax = 10;
    public float PzoomMin = -5;
    public float PzoomBase = -10;
    public float PzoomMax = -30;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            touchStart = GetWorldPosition(groundZ);
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            
            float difference = currentMagnitude - prevMagnitude;
            
            zoom(difference * 0.01f);
            }else if (Input.GetMouseButton(0)){
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            cam.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }
    
    public void MaxZoom(){
        if(!cam.orthographic){
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, PzoomMax);
        }else
        zoom(zoomOutMax);
    }
    
    public void MinZoom(){
        if(!cam.orthographic){
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, PzoomMin);
        }else
        zoom(zoomOutMin);
    }
    
    public void StandardZoom(){
        if(!cam.orthographic){
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, PzoomBase);
        }else 
        zoom(zoomOutBase);
    }
    
    private Vector3 GetWorldPosition(float z){
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0,0,z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
    
    void zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        if(!cam.orthographic){
            cam.transform.position += new Vector3(0, 0, increment);
            if(cam.transform.position.z > PzoomMin){
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, PzoomMin);
            }else if(cam.transform.position.z < PzoomMax){
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, PzoomMax);
            }
        }
    }
}
