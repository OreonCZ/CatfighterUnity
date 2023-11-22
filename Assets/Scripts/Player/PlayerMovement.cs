using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    bool isMoving = false;
    bool isSprinting = false;
    public Animator animator;
    public Slider slider;
    public float maxStamina = 50f;
    public float currentStamina;

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
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        //movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;

        //sprint
        if (isSprinting)
        {
            if (currentStamina > 0)
            {
                rb.velocity = moveInput * (movementSpeed * 2) * Time.fixedDeltaTime;
                currentStamina -= 20 * Time.deltaTime;
            }
        }
        if (!isSprinting && currentStamina < maxStamina)
        {
            rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;
            currentStamina += 20 * Time.deltaTime;
        }



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
            return;
        }
        }
}

