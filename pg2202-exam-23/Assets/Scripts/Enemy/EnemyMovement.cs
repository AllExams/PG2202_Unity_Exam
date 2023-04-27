using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float attackDistance = 2f; // Set the distance at which the enemy will attack
    public float attackDelay = 1f;
    private bool isAttacking = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Rotate the enemy to face the target
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);

        // Check if the enemy is close enough to attack
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= attackDistance && !isAttacking)
        {   
            StartCoroutine(AttackWithDelay());
        }

        if (animator.GetBool("IsDead"))
        {
            speed = 0f;
            target = null;
            Invoke("DelayedCode", 5f);
        }
    }
    
    void DelayedCode() {
        Destroy(gameObject);
    }

    IEnumerator AttackWithDelay()
    {
        isAttacking = true;
        //animator.SetTrigger("Attack");
        animator.SetBool("IsAttacking", true);
        Debug.Log("Enemy attacks target!");
        target.GetComponent<PlayerHealth>().TakeDamage(10); // Assumes the target has a PlayerHealth script
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }
}
