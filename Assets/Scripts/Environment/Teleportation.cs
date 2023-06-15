using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] Transform Tp;
    [SerializeField] GameObject player;
    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport)
        {
            StartCoroutine(Teleport());
            canTeleport = false;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(Tp.transform.position.x, Tp.transform.position.y, Tp.transform.position.z);

        yield return new WaitForSeconds(5);
        canTeleport = true;
    }
}