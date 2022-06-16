using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBond : MonoBehaviour
{
    public GameObject Start;
    public GameObject End;
    public LineRenderer lr;

    // Update is called once per frame
    void Update()
    {
        lr.gameObject.transform.position = Start.transform.position-new Vector3(0,0,.125f);
        lr.SetPosition(1, End.transform.localPosition-Start.transform.localPosition);
    }
}
