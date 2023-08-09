using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAttack : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collide) 
    {
        if(collide.gameObject.CompareTag("Enemy")) {
            EnemyHealth health = collide.gameObject.GetComponent<EnemyHealth>();
            if(health != null) {
                health.LoseHealth(damage);
            }
            Debug.Log("collision occured");
        }

        Destroy(gameObject);
    
    }
}
