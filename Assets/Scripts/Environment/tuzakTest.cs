using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tuzakTest : MonoBehaviour
   
{
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthBar1.instance.TakeDamage(damageAmount);
        }
    }

}
