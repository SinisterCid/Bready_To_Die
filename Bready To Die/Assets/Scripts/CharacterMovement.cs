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

    CharacterController controller;

    Vector3 velocity;

    Duck myDuck;

    string horizontalInputName;
    string verticalInputName;
    string jumpButtonName;

    // Start is called before the first frame update
    void Start()
    {
        myDuck = GetComponent<Duck>();
        controller = GetComponent<CharacterController>();

        horizontalInputName = myDuck.playerID + "_Horizontal";
        verticalInputName = myDuck.playerID + "_Vertical";
        jumpButtonName = myDuck.playerID + "_Jump";
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

        /*if (isGrounded)
        {
            GetAlignment();
        }
        else
        {
            transform.up = Vector3.up;
        }*/
    }

    void MovePlayer()
    {
        float xRaw = Input.GetAxisRaw(horizontalInputName);
        float zRaw = Input.GetAxisRaw(verticalInputName);
        float x = Input.GetAxis(horizontalInputName);
        float z = Input.GetAxis(verticalInputName);

        Vector3 lookDirection = new Vector3(xRaw, 0.0f, zRaw);
        if (xRaw != 0 || zRaw != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), rotateSpeed * Time.deltaTime);
        }

        Vector3 move = new Vector3(x, 0, z);
        controller.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown(jumpButtonName) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void GetAlignment()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, 3f, groundMask);

        Vector3 newUp = hit.normal;
        transform.up = newUp;
    }
}
