using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    bool isMoving = false;
    bool isWalking;
    bool isSprinting = false;
    public Animator animator;
    public Slider slider;
    public float maxStamina = 50f;
    public float currentStamina;
    public GameObject sprintBar;

    public float rollTime = 1f;
    public float rollCooldown;
    public float rollSpeed = 15;
    bool isRolling;
    bool canRoll = true;
    float currentRollTime;


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
        isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S);

            
                //roll
            if(canRoll && Input.GetKeyDown(KeyCode.Space) && currentStamina > 0)
            {
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                StartCoroutine(Roll(new Vector2(1f, 1f)));
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                {
                StartCoroutine(Roll(new Vector2(-1f, 1f)));
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                StartCoroutine(Roll(new Vector2(1f, -1f)));
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                StartCoroutine(Roll(new Vector2(-1f, -1f)));
                }

                else if (Input.GetKey(KeyCode.W)) {
                    StartCoroutine(Roll(Vector2.up));
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    StartCoroutine(Roll(Vector2.down));
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    StartCoroutine(Roll(Vector2.left));
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    StartCoroutine(Roll(Vector2.right));
                }
                else
                {
                return;
                }
                
            }

        //movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;

        if (slider.value < slider.maxValue)
        {
            sprintBar.SetActive(true);
        }
        else
        {
            sprintBar.SetActive(false);
        }

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
        

        IEnumerator Roll(Vector2 direction)
        {
            canRoll = false;
            currentStamina -= 20;
            Debug.Log(canRoll);
            isRolling = true;
            currentRollTime = rollTime;
            while(currentRollTime > 0f)
            {
                currentRollTime -= Time.deltaTime;

                rb.velocity = direction * rollSpeed;

                yield return null;
            }
            yield return new WaitForSeconds(rollCooldown);
            rb.velocity = new Vector2(0f, 0f);
            canRoll = true;
            Debug.Log(canRoll);
        }
    }
}

