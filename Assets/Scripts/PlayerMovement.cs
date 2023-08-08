using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float speed;
    private float horizontalInput;
    public int damangeAmount = 50;
    private float jump = 500;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Enemy")) {
            GreenGoblin enemy = collision.gameObject.GetComponent<GreenGoblin>();
            if(enemy != null) {
                enemy.TakeDamage(damangeAmount);
            }
           
        }
    }

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        // allows player to look left and right depending on where he's facing 
        if(horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;
        } else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetButtonDown("Jump")) {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    public bool Attack() 
    {
        return horizontalInput == 0; //&& isGrounded() 
    }

  
}
