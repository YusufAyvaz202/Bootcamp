using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandStorm : MonoBehaviour
{
    public Transform[] noktalar; 
    public float hiz = 5f; 

    private int mevcutNoktaIndex = 0;

    private void Start()
    {
        transform.position = noktalar[0].position;
    }

    private void Update()
    {
     
        Vector3 hedefNokta = noktalar[mevcutNoktaIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, hedefNokta, hiz * Time.deltaTime);

        if (transform.position == hedefNokta)
        {
            mevcutNoktaIndex++;

            if (mevcutNoktaIndex >= noktalar.Length)
                mevcutNoktaIndex = 0;
        }
    }
}
