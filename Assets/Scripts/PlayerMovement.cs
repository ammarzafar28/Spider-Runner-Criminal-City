using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GreenGoblin takeDamage;
    private Rigidbody2D rb;
    [SerializeField]private float speed;
    private float horizontalInput;
    private float jump = 500;

    public float webSpeed = 10f; 
    public GameObject webPrefab;
    public float jumpStrength = 30f;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        takeDamage = GetComponent<GreenGoblin>();
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

        if (Input.GetMouseButtonDown(0)) {
            ShootWeb();
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && IsJumpingOnHead(collision))
        {
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.LoseHealth(10); 
            }
            
        }
    }

    private bool IsJumpingOnHead(Collision2D collision)
    {
        // Calculate the position of Spiderman's feet and enemy's center
        Vector2 spidermanFeet = new Vector2(transform.position.x, transform.position.y - 0.5f); // Adjust offset as needed
        Vector2 enemyCenter = collision.gameObject.transform.position;

        // Check if Spiderman's feet are above the enemy's center
        return spidermanFeet.y >= enemyCenter.y;
    }

    void ShootWeb()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        Vector3 shootDirection = (mousePosition - transform.position).normalized;
        GameObject webInstance = Instantiate(webPrefab, transform.position, Quaternion.identity);
        if(webInstance != null) {
            Rigidbody2D rb = webInstance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity = shootDirection * webSpeed;
            }
        }   
    }
}

