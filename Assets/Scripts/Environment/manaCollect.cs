using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaCollect : MonoBehaviour
{
    public float collectedMana = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manaBar.instance.RefreshMana(collectedMana);
            Destroy(gameObject);
        }
    }
}
