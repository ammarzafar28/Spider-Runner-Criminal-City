using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAttack : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("collision");
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            if(health != null) {
                health.LoseHealth(damage);
            }
            Destroy(gameObject);
        }
    }
}

