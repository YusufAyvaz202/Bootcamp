using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBagTest : MonoBehaviour
{
    public float collectedAmount = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthBar1.instance.RefreshHealth(collectedAmount);
            Destroy(gameObject);
        }
    }
    
}
