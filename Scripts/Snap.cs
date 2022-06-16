using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes all instances of a script execute in Edit Mode
[ExecuteInEditMode]
[SelectionBase]

public class Snap : MonoBehaviour
{
    // Add an editor field, "SerializeField" with a custom range slider, from 1 to 20. Default value is 10.
    [SerializeField] [Range(1f, 20f)] float gridSizeX = 10f;
    [SerializeField] [Range(1f, 20f)] float gridSizeY = 10f;
    [SerializeField] [Range(0,4)] int gridType = 0;
    [SerializeField] [Range(0,3)] int objectType = 0;
    [SerializeField] bool master = false;
    public float offsetX = 0;
    public float offsetY = 0;
    
    static bool ame = false;
    static float mgsx;
    static float mgsy;
    static int mgt;
    static bool activate;
    
    public bool runThis;
    
    Vector3 snapPosition;
    int delay = 200;
    
    void Update()
    {
        if(master){
            mgsx = gridSizeX;
            mgsy = gridSizeY;
            mgt = gridType;
            ame = true;
            activate = runThis;
            }else if(ame){
            gridSizeX = mgsx;
            gridSizeY = mgsy;
            gridType = mgt;
        
        delay--;
        
        if(!activate||delay>0) return;
        
        switch(gridType){
            case 0:
            SquareSnap();
            break;
            case 1:
            HexSnap();
            break;
            case 2:
            TriSnap();
            break;
            case 3:
            HSTSnap();
            break;
            case 4:
            HTSSnap();
            break;
        }
        
        // Apply transformation
        transform.localPosition = new Vector3(snapPosition.x+offsetX, snapPosition.y+offsetY, transform.localPosition.z);
        }
    }
    
    void SquareSnap(){
        // When position of your object change, apply a new position on the x and y axed, based on your grid size.
        snapPosition.x = Mathf.RoundToInt(transform.localPosition.x / gridSizeX) * gridSizeX;
        snapPosition.y = Mathf.RoundToInt(transform.localPosition.y / gridSizeY) * gridSizeY;
    }
    
    void TriSnap(){
        int iy = Mathf.RoundToInt(transform.localPosition.y/gridSizeY);
        int ix = Mathf.RoundToInt(transform.localPosition.x/gridSizeX);
        if(iy%2==0^ix%2==0){
            snapPosition.x = Mathf.RoundToInt(transform.localPosition.x/gridSizeX)*gridSizeX;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,0);
            }else{
            float nearpoint = 1;
            nearpoint *= gridSizeX/3;
            nearpoint += Mathf.RoundToInt((transform.localPosition.x-nearpoint)/gridSizeX)*gridSizeX;
            snapPosition.x = nearpoint;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,60);
        }
        snapPosition.y = Mathf.RoundToInt(transform.localPosition.y / gridSizeY) * gridSizeY;
    }
    
    void HexSnap(){
        int ix = Mathf.RoundToInt(transform.localPosition.x/gridSizeX);
        snapPosition.x = Mathf.RoundToInt(transform.localPosition.x/gridSizeX)*gridSizeX;
        if(ix%2==0){
            snapPosition.y = Mathf.RoundToInt((transform.localPosition.y)/(gridSizeY))*gridSizeY;
            }else{
            float nearpoint = 1;
            nearpoint *= Mathf.Sign(transform.localPosition.y);
            nearpoint *= gridSizeY/2;
            nearpoint += Mathf.RoundToInt((transform.localPosition.y-nearpoint)/gridSizeY)*gridSizeY;
            snapPosition.y = nearpoint;
        }
    }
    
    void HSTSnap(){
        if(objectType==0) HexSnap();
        if(objectType==1){
            int ix = Mathf.RoundToInt(transform.localPosition.x/gridSizeX);
            snapPosition.x = Mathf.RoundToInt(transform.localPosition.x/gridSizeX)*gridSizeX;
            if(ix%2!=0){
                snapPosition.y = Mathf.RoundToInt((transform.localPosition.y)/(gridSizeY))*gridSizeY;
                }else{
                float nearpoint = 1;
                nearpoint *= Mathf.Sign(transform.localPosition.y);
                nearpoint *= gridSizeY/2;
                nearpoint += Mathf.RoundToInt((transform.localPosition.y-nearpoint)/gridSizeY)*gridSizeY;
                snapPosition.y = nearpoint;
            }           
        }
        if(objectType==2){
            int iy = Mathf.RoundToInt(transform.localPosition.y/(gridSizeY/4));
            int ix = Mathf.RoundToInt(transform.localPosition.x/(gridSizeX/2));
            snapPosition.y = Mathf.RoundToInt((transform.localPosition.y-gridSizeY/4)/(gridSizeY/2))*(gridSizeY/2)+gridSizeY/4;
            int sign = 1;
            float nearpoint = 1;
            nearpoint *= Mathf.Sign(transform.localPosition.x);
            nearpoint *= gridSizeX/2;
            nearpoint += Mathf.RoundToInt((transform.localPosition.x-nearpoint)/gridSizeX)*gridSizeX;
            snapPosition.x = nearpoint;
            if(ix%4==-1||ix%4==3)sign *= -1;
            if(iy%4==-1||iy%4==3)sign *= -1;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,30*sign);
        }
        if(objectType==3){
            int iy = Mathf.RoundToInt(transform.localPosition.y/(gridSizeY/2));
            int ix = (int)Mathf.Floor((transform.localPosition.x)/(gridSizeX));
            Debug.Log(ix%2+":"+iy%2);
            if((iy%2==0^ix%2==0)||(false)){
                snapPosition.x = Mathf.RoundToInt((transform.localPosition.x+gridSizeX*2/3)/(gridSizeX))*(gridSizeX)-gridSizeX*2/3;
                transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,0);
                }else{
                float nearpoint = 1;
                nearpoint *= gridSizeX/3;
                nearpoint += Mathf.RoundToInt((transform.localPosition.x-gridSizeX*1/3)/(gridSizeX))*(gridSizeX)+gridSizeX*1/3;
                snapPosition.x = nearpoint;
                transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,60);
            }
            snapPosition.y = Mathf.RoundToInt(transform.localPosition.y / (gridSizeY/2)) * gridSizeY/2;
        }
    }
    
    void HTSSnap(){
        if(objectType==0){
            SquareSnap();
        }
        if(objectType==1){
            snapPosition.x = Mathf.RoundToInt(transform.localPosition.x / (gridSizeX/2)) * (gridSizeX/2);
            snapPosition.y = Mathf.RoundToInt((transform.localPosition.y-gridSizeY/2) / gridSizeY) * gridSizeY + gridSizeY/2;
        }
        if(objectType==2){
            int iy = (int)Mathf.Floor(transform.localPosition.y/(gridSizeY/2));
            snapPosition.x = Mathf.RoundToInt((transform.localPosition.x-gridSizeX/2)/gridSizeX)*gridSizeX+gridSizeX/2;
            if(iy%2!=0){
                transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,90);
                snapPosition.y = Mathf.RoundToInt((transform.localPosition.y-3*gridSizeY/10) / (gridSizeY/2)) * gridSizeY/2+3*gridSizeY/10;
                }else{
                transform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,-90);
                snapPosition.y = Mathf.RoundToInt((transform.localPosition.y-gridSizeY/5) / (gridSizeY/2)) * gridSizeY/2+gridSizeY/5;
            }
        }
    }
}