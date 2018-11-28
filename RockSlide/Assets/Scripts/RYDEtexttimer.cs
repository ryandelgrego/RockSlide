using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RYDEtexttimer : MonoBehaviour
{

	
     public float time = 3; //Seconds to read the text

    void Start()
    {
        Destroy(gameObject, time);
    }
}
