using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lihgtningtrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "character")
        {
            Destroy(other.gameObject);
            //Y�ld�r�m �arpt���nda karakter silinir.Oyun bitii�inde yap�lacak �eyler burada yap�labilir.
        }
    }
}
