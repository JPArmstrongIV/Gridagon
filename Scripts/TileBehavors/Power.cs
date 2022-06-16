using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int power = 0;
    public bool isSource = false;
    public List<GameObject> Neighboors;
    public GameObject parent;
    public bool isAlive = true;
    public bool isSink = false;
    public Func runner;
    protected bool notTriggered = true;
    public bool isSlider = false;
    public int preload = 0;
    
    public GameObject touch;
    public List<Power> chain;
    
    void Start()
    {
        Light();
        if(isSlider&&Neighboors.Count > 0){
            foreach(GameObject go in Neighboors){
                Power p = go.GetComponent<Power>();
                while(p.Neighboors.Count==0){}
                p.Neighboors.Add(gameObject);
            }
        }
        if(Neighboors.Count <= preload){
            if(Neighboors==null)Neighboors = new List<GameObject>();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3.0f);
            Debug.Log(transform.parent.gameObject.name);
            foreach (var hitCollider in hitColliders){
                Transform go = hitCollider.transform.parent.Find("Capsule");
                if(go != null&& go.gameObject!=gameObject){
                    Neighboors.Add(go.gameObject);
                }
            }
            List<GameObject> Unique = new List<GameObject>();
            foreach(GameObject n in Neighboors){
                if(n!=gameObject&&!Unique.Contains(n))Unique.Add(n);
            }
            Neighboors = Unique;
        }
        Off(0);
    }
    
    void FixedUpdate(){
        if(chain.Count!=0)foreach(Power p in chain){
            if(p.power == 0){ 
                chain.Remove(p);
                break;
            }
        }
    }
    
    virtual public void Charge(Power feed){
        power = feed.power;
        touch = feed.gameObject;
        Light();
    }
    
    // Update is called once per frame
    virtual public void Check()
    {
        if(power>0&&isAlive){
            foreach (GameObject o in Neighboors)if(o!=null&&o.GetComponent<Power>().isAlive&&!o.GetComponent<Power>().isSource&&o.GetComponent<Power>().power == 0){
                RaycastHit hit;
                Vector3 ray = o.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider == o.GetComponent<Collider>()) {
                        o.GetComponent<Power>().Charge(this);
                        chain.Add(o.GetComponent<Power>());
                        o.GetComponent<Power>().Check();
                    }
                }
            }
        }else if(isAlive){
            foreach (GameObject o in Neighboors)if(o!=null&&o.GetComponent<Power>().isAlive&&o.GetComponent<Power>().power > 0){
                RaycastHit hit;
                Vector3 ray = o.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider == o.GetComponent<Collider>()) {
                        Charge(o.GetComponent<Power>());
                        o.GetComponent<Power>().chain.Add(this);
                        deepCheck();
                        return;
                    }
                }
            }
        }
        
    }
    
    virtual public void deepCheck()
    {
        if(isAlive){
            foreach (GameObject o in Neighboors)if(o!=null&&o.GetComponent<Power>().isAlive&&!o.GetComponent<Power>().isSource&&o.GetComponent<Power>().power == 0){
                RaycastHit hit;
                Vector3 ray = o.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider == o.GetComponent<Collider>()) {
                        o.GetComponent<Power>().Charge(this);
                        chain.Add(o.GetComponent<Power>());
                        o.GetComponent<Power>().Check();
                    }
                }
            }
        }
    }
    
    public virtual void Off(int depth){
        if(!isSource&&isAlive&&power>0){
            if(touch!=null&&touch.GetComponent<Power>().power==0){
                depower();
                return;
            }else if(touch != null){
                RaycastHit hit;
                Vector3 ray = touch.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider != touch.GetComponent<Collider>()){
                        depower();
                        return;
                    }
                }
            }
        }
        if(power!=0&&depth<1)foreach(Power p in chain){
            p.Off(depth++);
        }
    }
    
    public virtual void depower(){
        if(!isSource){
            if(isSink&&power>0) runner.offThing();
            power = 0;
            Light();
            foreach(Power p in chain){
                p.depower();
            }
            chain.Clear();
        }
    }
    
    public virtual void Light(){
        if(isSink&&power>0&&notTriggered){
            runner.doThing();
            notTriggered = false;
        }
        if(isAlive)
        parent.GetComponent<Color>().Light(power);
    if(power==0) 
    notTriggered = true;
    }
}
