using Unity.Mathematics;

using Unity.VisualScripting;

using UnityEngine;



public class PlayerController : MonoBehaviour

{

    // Layer mask for what is considered ground

    public float speed = 5.0f;

    public float rotationSpeed = 120.0f;

    private Rigidbody rb;

    public float jumpForce = 5.0f;



    private void Start()

    {

        rb = GetComponent<Rigidbody>();

    }

    void Update() { }

    void FixedUpdate()

    {

        // Move player based on vertical input.

        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * speed * verticalInput * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);



        // Move player based on horizontal input.

        float turn = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * rotationSpeed;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);



        if (Input.GetButtonDown("Jump"))

        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        }

    }

}

