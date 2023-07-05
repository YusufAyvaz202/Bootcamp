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
            //Yýldýrým çarptýðýnda karakter silinir.Oyun bitiiðinde yapýlacak þeyler burada yapýlabilir.
        }
    }
}
