using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public bool isMoving = false;
    public bool isWalking;
    bool isSprinting = false;
    public Animator animator;
    public Slider slider;
    public float maxStamina = 50f;
    public float currentStamina;
    public GameObject sprintBar;
    public Fight fight;
    public Milk milk;

    public float rollTime = 0.5f;
    public float rollCooldown = 0.5f;
    public float rollSpeed = 6;
    public bool isRolling = false;
    public float rollStaminaDrain = 20;
    bool canRoll = true;
    float currentRollTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
        slider.maxValue = maxStamina;
        Debug.Log(canRoll);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentStamina;
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S);

        
        //roll
        if (canRoll && Input.GetKeyDown(KeyCode.Space) && currentStamina > rollStaminaDrain && fight.canAttack && isWalking)
        {
            currentStamina -= rollStaminaDrain;

                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    StartCoroutine(Roll(new Vector2(1f, 1f)));
                    if (!fight.isFighting) {
                        animator.SetBool("RollingRight", true);
                    }
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                {
                    StartCoroutine(Roll(new Vector2(-1f, 1f)));
                    if (!fight.isFighting) {
                        animator.SetBool("RollingLeft", true);
                    }
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    StartCoroutine(Roll(new Vector2(1f, -1f)));
                    if (!fight.isFighting)
                    {
                        animator.SetBool("RollingRight", true);
                    }
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    StartCoroutine(Roll(new Vector2(-1f, -1f)));
                    if (!fight.isFighting)
                    {
                        animator.SetBool("RollingLeft", true);
                }
                }
                else if (Input.GetKey(KeyCode.W)) {
                    StartCoroutine(Roll(Vector2.up));
                    if (!fight.isFighting)
                    {
                        animator.SetBool("RollingBack", true);
                    }
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    StartCoroutine(Roll(Vector2.down));
                    if (!fight.isFighting)
                    {
                        animator.SetBool("Roll", true);
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    StartCoroutine(Roll(Vector2.left));
                    if (!fight.isFighting)
                    {
                        animator.SetBool("RollingLeft", true);
                    }
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    StartCoroutine(Roll(Vector2.right));
                    if (!fight.isFighting)
                    {
                        animator.SetBool("RollingRight", true);
                    }
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
        if (isSprinting && isWalking && milk.canDrink)
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
            isRolling = true;
            Debug.Log(isRolling);
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
            isRolling = false;
            Debug.Log(isRolling);
            Debug.Log("can attack: "+ fight.canAttack);

        }
    }
}

