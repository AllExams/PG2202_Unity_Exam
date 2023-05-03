using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private Animator animator;
    private bool hasDied = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f && !hasDied)
        {
			Die();      
        }
    }

    void Die()
    {
        hasDied = true;
		animator.SetBool("IsDead", true);
        GameplayControllerScript.instance.SetKillCounter();
		//Destroy(gameObject);
	}

}
