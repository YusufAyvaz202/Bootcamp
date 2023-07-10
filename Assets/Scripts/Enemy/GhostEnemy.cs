using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public Transform target; 
    public float moveSpeed = 5f; 
    public int damageAmount = 10;
    private void Update()
    {
        
        transform.LookAt(target);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hasar verme
            healthBar1.instance.TakeDamage(damageAmount);


        }
    }
}
