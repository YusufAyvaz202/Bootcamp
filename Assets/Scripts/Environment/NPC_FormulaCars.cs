using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FormulaCars : MonoBehaviour
{
    public Transform[] hedefNoktalar; 
    public float h�z = 5f; 

    private int mevcutHedefIndex = 0;

    private void Update()
    {
       
        Vector3 hedefNokta = hedefNoktalar[mevcutHedefIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, hedefNokta, h�z * Time.deltaTime);

      
        if (transform.position == hedefNokta)
        {
            mevcutHedefIndex++;

          
            if (mevcutHedefIndex >= hedefNoktalar.Length)
                mevcutHedefIndex = 0;
        }
    }
}
