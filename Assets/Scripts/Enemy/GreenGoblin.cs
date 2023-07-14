using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGoblin : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [SerializeField] private BoxCollider2D BoxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity;

    private void Update() 
    {
        coolDownTimer += Time.deltaTime;

        if (PlayerInSight()) {
            if(coolDownTimer >= attackCooldown) {
            // attack
            }
        }

        
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
