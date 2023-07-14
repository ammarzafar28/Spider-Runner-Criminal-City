using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebShooter : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float coolDownTimer = Mathf.Infinity;
    private PlayerMovement PlayerMovement;
    private Animator anim; 

    void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }
  
    // Update is called once per frame
    
    void Update()
    {
        if(Input.GetMouseButton(0) && coolDownTimer > attackCooldown && PlayerMovement.Attack()) {
            Attack();

            coolDownTimer += Time.deltaTime;
        }
    }
    

    public void Attack()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;

    }
}
