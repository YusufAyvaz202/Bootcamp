using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodableObject : MonoBehaviour
{
    public float countdownDuration = 3f;
    public float explosionRadius = 5f;
    public float explosionDamage = 15f;

    public Animator explosionAnimator;

    private bool isCountdownStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCountdownStarted)
        {
            isCountdownStarted = true;
            Invoke("StartCountdown", countdownDuration);
        }
    }

    private void StartCountdown()
    {
        // Patlama animasyonunu ba�lat
        explosionAnimator.SetTrigger("Explode");

        // Patlama fonksiyonunu �a��r (delay ile)
        Invoke("Explode", 1.5f);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Player'�n pozisyonunu kontrol et
                if (Vector3.Distance(transform.position, collider.transform.position) <= explosionRadius)
                {
                    // Player alanda ise hasar ver
                    healthBar1.instance.TakeDamage(explosionDamage);
                }
            }
        }

        // Bombay� yok et
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Patlama alan�n�n g�rsel g�sterimi i�in Gizmos kullan
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}