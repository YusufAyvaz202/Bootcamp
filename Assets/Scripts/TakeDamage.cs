using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class TakeDamage : MonoBehaviour
{

    private Mover mover;
    private Attack attack;
    public Boomerang boomerang;
    public VisualEffect poisonEffect;

    Coroutine Poison = null;

    public int health = 100;
    public bool isFrozen = false;

    private void Start()
    {
        poisonEffect.Stop();
        mover = GetComponent<Mover>();
        attack = GetComponent<Attack>();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boomerang") && boomerang.isReturning == false)
        {
            health -= 5;
        }
        if (other.CompareTag("FrozenBoomerang") && boomerang.isReturning == false)
        {
            health -= 10;
            isFrozen = true;
            mover.enabled = false;
            attack.enabled = false;
            StartCoroutine(ExitFreeze());
        }

        

        if (Poison == null&& other.CompareTag("PoisonBoomerang") && boomerang.isReturning == false)
        {
            Poison = StartCoroutine(PoisonEffect());

        }

    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (Poison != null&& other.CompareTag("Ayran"))
        {
            StopCoroutine(Poison);
            Poison = null;
        }
    }

    private IEnumerator ExitFreeze()
    {
        yield return new WaitForSeconds(3f); // Donma süresi burada 3 saniye olarak varsayýlmýþtýr, ihtiyaca göre deðiþtirilebilir

        isFrozen = false;
        mover.enabled = true;
        attack.enabled = true;
    }

   IEnumerator PoisonEffect()
    {
        poisonEffect.Play(); 
        health -= 2;
        yield return new WaitForSeconds(1.2f);
        health -= 2;
        yield return new WaitForSeconds(1.2f);
        health -= 2;
        yield return new WaitForSeconds(1.2f);
        health -= 2;
        yield return new WaitForSeconds(1.2f);
        health -= 2;
        Poison = null;
        poisonEffect.Stop();

    }

}
