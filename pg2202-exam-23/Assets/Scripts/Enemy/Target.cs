using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        //Destroy(gameObject);
    }
}
