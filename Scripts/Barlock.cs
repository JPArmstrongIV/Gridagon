using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barlock : MonoBehaviour
{
    public UnityEngine.UI.Scrollbar sb;
    public string id;

    void Start()
    {
        if(PlayerPrefs.HasKey(id))
            sb.value = PlayerPrefs.GetFloat(id);
    }
}
