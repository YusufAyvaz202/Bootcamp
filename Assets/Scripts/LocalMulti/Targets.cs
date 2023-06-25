using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public CinemachineTargetGroup targetbrain;

    void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {

        //Find players in scene
        Transform p1 = GameObject.Find("Player 1(Clone)").transform;
        Transform p2 = GameObject.Find("Player 2(Clone)").transform;

        yield return new WaitForSeconds(0.0001f);
        //Add members to follow group

        targetbrain.AddMember(p1, 1f, 0f);
        targetbrain.AddMember(p2, 1f, 0f);

    }
}
