using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public CinemachineTargetGroup targetbrain;
    public GameObject[] Temp;

    void Start()
    {
        Temp = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        foreach (var item in Temp)
        {
            targetbrain.AddMember(item.transform, 5f, 1.5f);
        }

        //Transform p1 = GameObject.Find("Player 1(Clone)").transform;
        //Transform p2 = GameObject.Find("Player 2(Clone)").transform;

        yield return new WaitForSeconds(0.0001f);

        

    }
}
