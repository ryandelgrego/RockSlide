using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RYDEdestroyByContact : MonoBehaviour {

    public GameObject playerExplosion;
    public GameObject explosion;
    private RYDEgameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<RYDEgameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'RYDEgameController' script");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            
        }

        if (col.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            gameController.GameOver();
        }

        {
            
        }
    }
}
