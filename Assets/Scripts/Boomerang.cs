using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 5f;
    public float returnDistance = 10f;
    private bool isReturning = false;
    public Vector3 initialPosition;
    public float rotationSpeed = 360f;


    private void Start()
    {
        initialPosition = transform.position;
    }

    public void ChangePos(Transform pos)
    {
        initialPosition = pos.position;
    }

    private void Update()
    {
        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            if (transform.position == initialPosition)
            {
                Destroy(gameObject);
            }


        }
        else
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }


    }

    public void Throw()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;

        Invoke("StartReturning", returnDistance / speed);
    }

    private void StartReturning()
    {
        isReturning = true;
    }


}
