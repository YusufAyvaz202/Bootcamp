using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Boomerang boomerangPrefab;
    private Boomerang currentBoomerang;
    public Transform meeple;
    private bool attacked;

    void Start()
    {
        
    }
    public void IsAttacked(bool attack)
    {
        attacked = attack;
    }
    void Update()
    {
        if (attacked && currentBoomerang == null)
        {
            ThrowBoomerang();
        }
        if (currentBoomerang != null)
        {
            currentBoomerang.initialPosition = this.transform.position;
        }
    }

    private void ThrowBoomerang()
    {
        meeple = this.gameObject.transform.GetChild(0);

        //meeple = this.transform;

        currentBoomerang = Instantiate(boomerangPrefab, meeple.position, transform.rotation);
        currentBoomerang.Throw();
    }
}
