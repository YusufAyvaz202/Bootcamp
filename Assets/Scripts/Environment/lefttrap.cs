using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lefttrap : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float forceSpeed;
    public float time;
    public float interval;
    public bool timer;
    // Start is called before the first frame update
    void Start()
    {
        forceSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.right * forceSpeed;

        if (timer)
        {
            time += Time.deltaTime;
            if (time > interval)
            {
                if (forceSpeed > 0)
                {
                    forceSpeed = -speed;
                    timer = false;
                    time = 0;
                }
                else if (forceSpeed < 0)
                {
                    forceSpeed = speed;
                    timer = false;
                    time = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            timer = true;
        }
    }
}
