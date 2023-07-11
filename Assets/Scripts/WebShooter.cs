using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebShooter : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float coolDownTimer = Mathf.Infinity;
    private PlayerMovement PlayerMovement;

    void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
    }
  
    // Update is called once per frame
    /*
    void Update()
    {
        if(Input.GetMouseButton(0) && coolDownTimer > attackCooldown && PlayerMovement.canAttack()) {
            Attack();
        }
    }
    */

    public void Attack()
    {
        coolDownTimer = 0;

    }
}
