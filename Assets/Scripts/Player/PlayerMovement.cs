using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    bool isMoving = false;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        void stopMoving()
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("Walking", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingUp", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WalkingUp", true);
            animator.SetBool("Walking", false);
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", false);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Walking", false);
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", true);
            animator.SetBool("WalkingUp", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkingRight", true);
            animator.SetBool("Walking", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingUp", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("Walking", true);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingUp", false);
        }

        else if (!isMoving)
        {
            stopMoving();
        }
       

        Vector2 moveInput = new Vector2(moveX, moveY).normalized;

        rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;

    }
}
