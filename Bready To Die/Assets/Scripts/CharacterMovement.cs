using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float rotateSpeed;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    float currentX;
    float currentZ;

    public bool isGrounded;
    public bool alignToGround;

    CharacterController controller;

    Vector3 velocity;
    Vector3 lookDirection;
    Vector3 alignment;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        MovePlayer();
        Jump();

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded)
        {
            alignToGround = true;
        }
        else
        {
            alignToGround = false;
        }
    }

    void MovePlayer()
    {
        float xRaw = Input.GetAxisRaw("Horizontal");
        float zRaw = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        lookDirection = new Vector3(xRaw, 0.0f, zRaw);
        Vector3 move = new Vector3(x, 0, z);

        GetAlignment();

        if ((xRaw != 0 || zRaw != 0) && isGrounded)
        {
            
            Vector3 temp = Vector3.Cross(alignment, lookDirection);
            Vector3 myDirection = Vector3.Cross(temp, alignment);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(myDirection), rotateSpeed * Time.deltaTime);            
        }
        else if ((xRaw != 0 || zRaw != 0) && !isGrounded)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), rotateSpeed * Time.deltaTime);
        }

            controller.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            var currentRotation = transform.rotation;
            currentRotation.x = 0;
            currentRotation.z = 0;
            transform.rotation = currentRotation;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void GetAlignment()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, 2f, groundMask);
        alignment = hit.normal;
    }
}
