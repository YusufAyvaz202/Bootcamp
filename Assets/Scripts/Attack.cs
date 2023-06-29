using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Boomerang boomerangPrefab;
    public Boomerang frozonBoomerangPrefab;
    public Boomerang NormalBoomerangPrefab;
    private Boomerang currentBoomerang;
    public Transform meeple;
    private bool attacked;

    void Start()
    {
        boomerangPrefab = NormalBoomerangPrefab;
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
            boomerangPrefab = NormalBoomerangPrefab;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FrozenPOWER"))
        {
            boomerangPrefab = frozonBoomerangPrefab;
        }
    }
}
