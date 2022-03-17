using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

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

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        GetInputs();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // Stop focusing on objects
        //    }
        //}
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


        }

    }

    void CalculateMovement()
    {
        //jump

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Debug.Log(isGrounded);

        if (jumpPressed)
        {
            if (isGrounded)
            {
                isJumping = false;
                velocity.y = jumpVel;
            }
            else if (!isGrounded)
            {
                jumpPressed = false;
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