using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RYDEplayercontroller : MonoBehaviour {
    
    public float speed;
   
    private Rigidbody2D rb2d;
    private bool facingRight = true;
    
    
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
   
}