using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    [SerializeField] private float speed;
    private bool hit;
    private float direction;

    private BoxCollider2D BoxCollider;
    private Animator anim; 

    private void Awake() 
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        hit = true;
        BoxCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false; 
        BoxCollider.enabled = true;
    }
}
