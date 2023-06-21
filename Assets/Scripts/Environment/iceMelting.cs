using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceMelting : MonoBehaviour
{
    public float meltSpeed = 0.1f;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (transform.localScale.x > 0 && transform.localScale.z>0)
        {
            Vector3 newScale = transform.localScale;
            newScale -= new Vector3(meltSpeed * Time.deltaTime, 0, meltSpeed * Time.deltaTime);
            transform.localScale = newScale;
        }
    }
}
