using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private Mover mover;
    private Attack attack;
    public Boomerang boomerang;

    public int health = 100;
    public bool isFrozen = false;
    private bool isPlayerFrozen = false;

    private void Start()
    {
        mover = GetComponent<Mover>();
        attack = GetComponent<Attack>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boomerang") && boomerang.isReturning == false)
        {
            health -= 5;
            Debug.Log("oldu1");
        }
        if (other.CompareTag("FrozenBoomerang") && boomerang.isReturning == false)
        {
            health -= 10;
            isFrozen = true;
            mover.enabled = false;
            attack.enabled = false;
            Debug.Log("oldu2");
            StartCoroutine(ExitFreeze());
        }
    }

    private IEnumerator ExitFreeze()
    {
        yield return new WaitForSeconds(3f); // Donma süresi burada 3 saniye olarak varsayýlmýþtýr, ihtiyaca göre deðiþtirilebilir

        isFrozen = false;
        mover.enabled = true;
        attack.enabled = true;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("FrozenBoomerang") && isFrozen)
    //    {
    //        isPlayerFrozen = true;
    //        StartCoroutine(ExitPlayerFreeze());
    //    }
    //}

    //private IEnumerator ExitPlayerFreeze()
    //{
    //    yield return new WaitForSeconds(2f); // Oyuncunun donma süresi burada 2 saniye olarak varsayýlmýþtýr, ihtiyaca göre deðiþtirilebilir

    //    isPlayerFrozen = false;
    //}

    //private void Update()
    //{
    //    if (!isPlayerFrozen)
    //    {
    //        // Oyuncunun hareket kodlarý buraya gelecek
    //    }
    //}

}
