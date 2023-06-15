using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geriİtmeFNC : MonoBehaviour
{
    public float itmeGucu = 10f;
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 itmeYonu = transform.position - collision.transform.position;
            itmeYonu.y = 0f; // Y ekseninde itme yapmak istemiyorsanız bu satırı ekleyin.
            itmeYonu.Normalize();

            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(-itmeYonu * itmeGucu, ForceMode.Impulse);
        }
    }
}