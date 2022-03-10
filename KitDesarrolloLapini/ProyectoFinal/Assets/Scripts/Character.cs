using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movSpeed;
    float hAxis, vAxis;
    public bool jumping, isGrounded;
    public float jumpForce;
    public float maxVel;
    public float slideSpeed;
    public float slideAcceleration;
    public float slideTime;
    bool slide;

    Animator animator;
    Rigidbody rb;
    BoxCollider m_Collider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        m_Collider = GetComponent<BoxCollider>();
    }

    void Update()
    {

        DoInputs();
        DoAnimator();
    }

    void DoInputs()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        if(hAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0,180, 0);
        }else if(hAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumping = true;
        }
    }

    void DoAnimator()
    {

        if (jumping)
        {
            animator.SetBool("Jump", true);
        }else if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }

        animator.SetFloat("RunCon", Mathf.Abs(hAxis));
        animator.SetBool("Slide", slide);
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(transform.right * hAxis * movSpeed);
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            slide = true;
        }

        if (slide == true)
        {
            m_Collider.size = new Vector3(10f, 2f, 2f);
            m_Collider.center = new Vector3(0f, -3.5f, 0f);
            rb.velocity += transform.right*slideAcceleration;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, slideSpeed);
            Invoke("RestoreSlide", slideTime);
        }
        else
        {
            m_Collider.size = new Vector3(2f, 10f, 2f);
            m_Collider.center = new Vector3(0f, 0f, 0f);
        }

        //salto sin perder velocidad, sin perder altura

        if (!slide)
        {
            float yVel = rb.velocity.y;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel);
            rb.velocity = new Vector3(rb.velocity.x, yVel, rb.velocity.z);
        }

        if (jumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumping = false;
            isGrounded = false;
        }
    }

    void RestoreSlide(){
        slide = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        Debug.Log(other.rigidbody);
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
