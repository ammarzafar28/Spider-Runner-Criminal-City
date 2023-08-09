using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DocOck : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [SerializeField] private BoxCollider2D BoxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity;

    public int maxHealth = 50;
    private int currentHealth;

    public string newSceneName = "VultureScene-3";

    private void Start() 
    {
        currentHealth = maxHealth;
    }

    private void Update() 
    {
        coolDownTimer += Time.deltaTime;

        if (PlayerInSight()) {
            if(coolDownTimer >= attackCooldown) {
            // attack
            }
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        if(currentHealth <= 0) {
            Die();
        }
    }

    private void Die() 
    {
        Destroy(gameObject);

        SceneManager.LoadScene(newSceneName);
        
    }

    private bool PlayerInSight() 
    {
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center + transform.right * range * transform.localScale.x, BoxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * range * transform.localScale.x, BoxCollider.bounds.size);
    }
   
}
