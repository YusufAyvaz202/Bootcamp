using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaryTrap : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float damageAmount = 10f;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hasar verme
            healthBar1.instance.TakeDamage(damageAmount);

            // Geri itme
          
        }
    }
    

    private void Update()
    {
        // Küpün dönmesi
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}