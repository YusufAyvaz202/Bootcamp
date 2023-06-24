using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3f;
    [SerializeField]
    private float dashSpeed, dashTime, dashCooldown;

    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;


    public Boomerang boomerangPrefab;
    private Boomerang currentBoomerang;
    public Transform meeple;

    private bool jumped;
    private bool dashed;
    private bool groundedPlayer;
    private bool attacked;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MoveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        dashCooldown -= Time.deltaTime;
        if (dashed && dashCooldown <= 0)
        {
            StartCoroutine(Dash());
        }

        if (attacked && currentBoomerang == null)
        {
            ThrowBoomerang();
        }
        if (currentBoomerang!=null)
        {
            currentBoomerang.initialPosition = this.transform.position;
        }

    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public void IsJump(bool atladý)
    {
        jumped = atladý;
    }

    public void IsDashing(bool dash)
    {
        dashed = dash;
    }
    public void IsAttacked(bool attack)
    {
        attacked = attack;
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(moveDirection * dashSpeed * Time.deltaTime);
            yield return null;
            dashCooldown = 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Velocity")) //Velocity tagý bir objeye verilince power up çalýþýyor.
        {
            StartCoroutine(TakeVelocity());
        }

    }

    IEnumerator TakeVelocity()
    {
        MoveSpeed = 6f;
        Debug.Log("Alýndý 2.");
        yield return new WaitForSeconds(3);
        MoveSpeed = 3f;

    }

    private void ThrowBoomerang()
    {
        meeple = this.gameObject.transform.GetChild(0);

        
        // Boomerang'ýn fýrlatýldýðý pozisyona ve rotasyona sahip bir klonunu oluþtur
        currentBoomerang = Instantiate(boomerangPrefab, meeple.position, transform.rotation);
        currentBoomerang.Throw();
    }
}