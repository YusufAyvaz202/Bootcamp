using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float jumpSpeed = 1.6f;
    public float speed = 6.0f;
    public float gravity = 9.81f;
    public float pushForce = 10.0f;
    public float pushDuration = 1.0f;
    public bool obstacle1=false;
    public bool obstacle2=false;

    private Vector3 move = Vector3.zero;
    private float pushTimer = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            move = transform.right * x + transform.forward * z;

            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }
        }

        move.y -= gravity * Time.deltaTime;

        if (pushTimer > 0)
        {
            pushTimer -= Time.deltaTime;
        }

        characterController.Move(move * speed * Time.deltaTime);

        if(obstacle1==true && obstacle2==true )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle1")
        {
            obstacle1 = true;
        }
        if (other.tag == "obstacle2")
        {
            obstacle2 = true;
        }
    }

}
