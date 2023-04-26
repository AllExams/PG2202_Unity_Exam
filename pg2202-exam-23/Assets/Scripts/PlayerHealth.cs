using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public GameObject deathEffect;
    public AudioSource audioSource;
    public AudioClip damageSound;

    void Start() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log("Player takes " + damage + " damage! Current health: " + currentHealth);

        if (currentHealth <= 0) {
            Die();
        } else {
            // Play damage sound
            audioSource.PlayOneShot(damageSound);
        }
    }

    void Die() {
        gameObject.SetActive(false);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Add game over behavior here, such as reloading the level or showing a game over screen.
    }
}
