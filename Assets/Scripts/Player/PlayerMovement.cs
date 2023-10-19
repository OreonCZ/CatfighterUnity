using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    bool isMoving = false;
    public Animator animator;
    public Slider slider;
    public int maxStamina = 100;
    public int currentStamina;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
        slider.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentStamina;

        //movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
       
       
         
            if (Input.GetKey(KeyCode.LeftShift))
            {
            rb.velocity = moveInput * (movementSpeed * 2) * Time.fixedDeltaTime;
            }
             else
            {
            rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;
            }

/*
if(currentStamina > 0) { 
switch (Input.GetKey(KeyCode.LeftShift))
{
    case true:
        rb.velocity = moveInput * (movementSpeed * 2) * Time.fixedDeltaTime;
        currentStamina-=1;
        break;
    case false:
        rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;
        currentStamina+=1;
        break;
}
}
*/

void stopMoving()
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("Walking", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingUp", false);
        }

        //animation changer
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

        }
}




