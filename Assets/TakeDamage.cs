using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private Mover mover;
    public Boomerang boomerang;

    public int health = 100;
    public bool isFrozen = false;
    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boomerang") && boomerang.isReturning==false)
        {
            health = -5;
            Debug.Log("oldu1");

        }
        if (other.CompareTag("FrozenBoomerang") && boomerang.isReturning==false)
        {
            health = -10;
            isFrozen = true;
            mover.enabled = false;
            Debug.Log("oldu2");
            StartCoroutine(ExitFreeze());
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Boomerang")&& !boomerang.isReturning)
    //    {
    //        health = -5;
    //        Debug.Log("oldu1");

    //    }
    //    if (collision.collider.CompareTag("FrozenBoomerang")&& !boomerang.isReturning)
    //    {
    //        health = -10;
    //        isFrozen = true;
    //        mover.enabled = false;
    //        Debug.Log("oldu2");
    //        StartCoroutine(ExitFreeze());
    //    }
    //}


    IEnumerator ExitFreeze()
    {
        yield return new WaitForSeconds(3f);
        mover.enabled = true;
    }
}
