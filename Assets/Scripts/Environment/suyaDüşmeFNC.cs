using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suyaDüşmeFNC : MonoBehaviour
{
    public string groundTag = "Ice"; // Zeminin tag'ini buradan ayarlayabilirsiniz
    public float destroyDelay = 3f; // Nesnenin yok olma gecikmesi

    private bool isOnGround = false;

    private void Update()
    {
        if (!isOnGround)
        {
            // Yere düşme işlemini kontrol et
            CheckGround();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Zeminle teması kontrol et
        if (collision.gameObject.CompareTag(groundTag))
        {
            isOnGround = true;
        }
    }

    private void CheckGround()
    {
        // Zeminde olup olmadığını kontrol et
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.CompareTag(groundTag))
            {
                isOnGround = true;
            }
            else
            {
                // Yere düşmediyse, düşür ve belirtilen süre sonra yok et
                FallAndDestroy();
            }
        }
    }

    private void FallAndDestroy()
    {
        // Yere düşme animasyonu veya işlemleri buraya ekleyebilirsiniz

        // Nesneyi belirtilen süre sonra yok et
        Destroy(gameObject, destroyDelay);
    }
}
