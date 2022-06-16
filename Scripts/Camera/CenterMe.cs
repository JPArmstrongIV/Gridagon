using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMe : MonoBehaviour
{
    public Map grid;
    float x;
    float y;
    public float X;
    public float Y;
        
    // Start is called before the first frame update
    void Start()
    {
        if(grid!=null){
            x = X+grid.sizeX*grid.offsetX/2-1;
            y = Y+grid.sizeY*grid.offsetY/2;
            CenterX();
            CenterY();
        }else{
            x = X;
            y = Y;
        }
    }

    public void CenterX()
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void CenterY()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
