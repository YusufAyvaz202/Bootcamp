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
        // Patlama animasyonunu baþlat
        explosionAnimator.SetTrigger("Explode");

        // Patlama fonksiyonunu çaðýr (delay ile)
        Invoke("Explode", 1.5f);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Player'ýn pozisyonunu kontrol et
                if (Vector3.Distance(transform.position, collider.transform.position) <= explosionRadius)
                {
                    // Player alanda ise hasar ver
                    healthBar1.instance.TakeDamage(explosionDamage);
                }
            }
        }

        // Bombayý yok et
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Patlama alanýnýn görsel gösterimi için Gizmos kullan
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}