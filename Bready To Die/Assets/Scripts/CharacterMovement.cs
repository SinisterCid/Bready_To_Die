using UnityEngine;
using UnityEngine.Analytics;

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
    public float walkSpeed;

    public bool isGrounded;
    public bool alignToGround;

    CharacterController controller;

    public Vector3 velocity;
    Vector3 lookDirection;
    Vector3 alignment;

    Duck myDuck;
    Jab jabScript;

    string horizontalInputName;
    string verticalInputName;
    string jumpButtonName;
    string jabButtonName;

    // Start is called before the first frame update
    void Start()
    {
        myDuck = GetComponent<Duck>();
        controller = GetComponent<CharacterController>();
        jabScript = GetComponentInChildren<Jab>();

        horizontalInputName = myDuck.playerID + "_Horizontal";
        verticalInputName = myDuck.playerID + "_Vertical";
        jumpButtonName = myDuck.playerID + "_Jump";
        jabButtonName = myDuck.playerID + "_Jab";
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        InputControl();
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
        float xRaw = Input.GetAxisRaw(horizontalInputName);
        float zRaw = Input.GetAxisRaw(verticalInputName);
        float x = Input.GetAxis(horizontalInputName);
        float z = Input.GetAxis(verticalInputName);
        walkSpeed = Mathf.Abs(x) + Mathf.Abs(z);
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
        if (Input.GetButtonDown(jumpButtonName) && isGrounded)
        {
            var currentRotation = transform.rotation;
            currentRotation.x = 0;
            currentRotation.z = 0;
            transform.rotation = currentRotation;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            //analytics jump event 
            Analytics.CustomEvent("PlayerJumps");
        }
    }


    void GetAlignment()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, 2f, groundMask);
        alignment = hit.normal;
    }

    void InputControl()
    {
        if (Input.GetButtonDown(jabButtonName))
        {
            jabScript.DoJab();
            Analytics.CustomEvent("PlayerJab");
        }
    }
}
