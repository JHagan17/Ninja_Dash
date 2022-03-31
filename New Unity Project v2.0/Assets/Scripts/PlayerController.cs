using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public static Transform cam;
    private Animator anim;
    

    public float speed = 6f;
    public float gravity = 9.81f;
    public float jumpVel;
    Vector3 velocity;
    bool isGrounded, jumpPressed, isJumping;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;




    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        GetInputs();

        //if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("We Hit" + hit.collider.name + " "+ hit.point);
                 //Stop focusing on objects
           }
       }
    }

    void GetInputs()
    {
        jumpPressed = Input.GetButtonDown("Jump");

        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);

            if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("Run", true);
            } else
            {
                anim.SetBool("Run", false);
            }


        }

    }

    void CalculateMovement()
    {
        //jump

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        

        if (jumpPressed)
        {
            if (isGrounded)
            {
                isJumping = true;
                velocity.y = jumpVel;
                anim.SetBool("Jump", true);
            }
            else if (!isGrounded)
            {
                jumpPressed = false;
                //isJumping = false;
                anim.SetBool("Jump", false);
            }
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}