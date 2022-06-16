using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject tile;
    public int sizeX = 10;
    public int sizeY = 10;
    public float offsetX = 1.0f;
    public float offsetY = 1.0f;
    public float oddset = 0.0f;
    public float oddrack = 0.0f;
    public float rowset = 0.0f;
    public int dissing = -1;
    public int dislock = -1;
    public float disset = 0.0f;
    public float oddtateX = 0.0f;
    public float oddtateY = 0.0f;
    public float oddtateZ = 0.0f;
    public bool preSet = false;
    
    void Start(){
    
        if(!preSet)Generate();
        
    }
    
    public void reGenerate(){
        
    }
    
    void Generate(){
        float x = 0.0f;
        float y = 0.0f;
        
        GetComponent<MotherPower>().powers = new List<GameObject>(sizeX*sizeY);
        
        for(int ix = 0; ix < sizeX;ix++){
            x = ix*offsetX;
            if(ix%2 == 1){
                x+=oddrack;
            }
            for(int iy = 0; iy < sizeY;iy++){
                bool act = false;
                y = iy*offsetY;
                if(ix%4>1){
                    y+=rowset;
                }
                if(ix%2==1){ 
                    y+=oddset;
                }
                if(ix%dissing==dislock){
                    y+=disset;
                }
                Vector3 dif = new Vector3(x, y, 0);
                Quaternion rotate;
                if(ix%2==1){
                    rotate = new Quaternion(oddtateX,oddtateY,oddtateZ,1);
                    act = true;
                }else rotate = Quaternion.identity;
                var go = Instantiate(tile, transform.position + dif, rotate);
                go.GetComponent<TileSpawn>().hold = gameObject;
                go.GetComponent<TileSpawn>().dotate = act;
            }
        }
    }
}
