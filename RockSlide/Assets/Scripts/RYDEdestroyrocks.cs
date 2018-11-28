using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RYDEdestroyrocks : MonoBehaviour {

    
    private void OnCollisionEnter2D(Collision2D col)
    {
        

        if (col.gameObject.tag == "Rock")
        {
           
            Destroy(col.gameObject);
            Debug.Log("is this happening");
        }


    }
}
