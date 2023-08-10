using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [SerializeField] private float speed;
    private float horizontalInput;
    private float jump = 500;

    public float webSpeed = 10f; 
    public GameObject webPrefab;
    public float jumpStrength = 20f;
    private bool shoot = true;
    public float webCooldownTime = 1f;

    [SerializeField] private LayerMask jumpingGround;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
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

        if(Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        
        if(!shoot) {
            webCooldownTime -= Time.deltaTime;
            if(webCooldownTime <= 0) {
                shoot = true;
                webCooldownTime = 1f;
            }
        }

        if (Input.GetMouseButtonDown(0) && shoot) {
            ShootWeb();
            shoot = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpingGround);

    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && JumpingOnHead(collision))
        {
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.LoseHealth(10); 
            }
            
        }
    }

    private bool JumpingOnHead(Collision2D collision)
    {
        Vector2 Feet = new Vector2(transform.position.x, transform.position.y - 0.5f); 
        Vector2 enemyCenter = collision.gameObject.transform.position;

        return Feet.y >= enemyCenter.y;
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

