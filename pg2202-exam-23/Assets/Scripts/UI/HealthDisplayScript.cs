using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayScript : MonoBehaviour
{

    private int health = 10;
    public TextMeshProUGUI healthText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH : " + health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health = health - 1;
        }
    }
}
