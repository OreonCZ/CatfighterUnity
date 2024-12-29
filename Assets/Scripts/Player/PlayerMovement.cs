using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public bool isMoving = false;
    public bool isWalking;
    [HideInInspector] public bool canWalk = true;
    bool isSprinting = false;
    Animator animator;
    Slider slider;
    public float maxStamina;
    public float currentStamina;
    Fight fight;
    Milk milk;
    private float rollTime = 0.5f;
    private float rollCooldown = 0.3f;
    private float rollSpeed;
    public bool isRolling = false;
    private float rollStaminaDrain = 20;
    public bool canRoll = true;
    float currentRollTime;
    GameObject enemy;
    GameObject sprintBar;
    bool ignore = false;

    GameObject player;
    PlayerStats playerStats;
    Parry parry;

    // Start is called before the first frame update
    void Start()
    {
        sprintBar = GameObject.FindGameObjectWithTag(ObjectTags.staminaBorder.ToString());
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());

        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        fight = gameObject.GetComponent<Fight>();
        milk = gameObject.GetComponent<Milk>();

        playerStats = player.GetComponent<PlayerStats>();
        slider = sprintBar.GetComponent<Slider>();
        parry = player.GetComponent<Parry>();

        movementSpeed = playerStats.playerMovementSpeed;
        maxStamina = playerStats.playerMaxStamina;
        currentStamina = maxStamina;
        slider.maxValue = maxStamina;

        enemy = GameObject.FindGameObjectWithTag(ObjectTags.Enemy.ToString());
        rollSpeed = movementSpeed / 30;
    }

    // Update is called once per frame
    void Update()
    {
        //enemy check
        if (!enemy)
        {
            ignore = true;
        }
        else if (enemy)
        {
            ignore = false;
        }

        slider.value = currentStamina;
        if (!isRolling) {
            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }
        isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S);


        AnimationChanger();
        Moving();

    }
    void Moving()
    {
        //movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;

        //sprint

        if (slider.value < slider.maxValue)
        {
            sprintBar.SetActive(true);
        }
        else
        {
            sprintBar.SetActive(false);
        }
        if (isSprinting && isWalking && milk.canDrink && !parry.isParrying)
        {
            if (currentStamina > 0)
            {
                rb.velocity = moveInput * (movementSpeed * 2) * Time.fixedDeltaTime;
                currentStamina -= 20 * Time.deltaTime;
            }
        }
        if (!isSprinting && currentStamina < maxStamina || !isWalking || parry.isParrying)
        {
            if (currentStamina < maxStamina)
            {
                rb.velocity = moveInput * movementSpeed * Time.fixedDeltaTime;
                currentStamina += 20 * Time.deltaTime;
            }
        }

        //roll
        if (canRoll && Input.GetKeyDown(KeyCode.Space) && currentStamina > rollStaminaDrain && fight.canAttack && isWalking)
        {
            currentStamina -= rollStaminaDrain;

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(Roll(new Vector2(1f, 1f)));
                if (!fight.isFighting)
                {
                    animator.SetBool("RollingRight", true);
                }
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(Roll(new Vector2(-1f, 1f)));
                if (!fight.isFighting)
                {
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
            else if (Input.GetKey(KeyCode.W))
            {
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
    }


    //animation changer
    void AnimationChanger()
    {
        if (canWalk) {
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
    void stopMoving()
    {
        animator.SetBool("WalkingRight", false);
        animator.SetBool("Walking", false);
        animator.SetBool("WalkingLeft", false);
        animator.SetBool("WalkingUp", false);
    }

    IEnumerator Roll(Vector2 direction)
    {
        canRoll = false;
        isRolling = true;
        /*if (!ignore)
        {
            enemy.GetComponent<BoxCollider2D>().enabled = false;
        }
        */
        currentRollTime = rollTime;
        while (currentRollTime > 0f)
        {
            currentRollTime -= Time.deltaTime;
            rb.velocity = direction * rollSpeed;

            yield return null;
        }
        yield return new WaitForSeconds(rollCooldown);
        rb.velocity = new Vector2(0f, 0f);
       /*8if (!ignore)
        {
            //enemy.GetComponent<BoxCollider2D>().enabled = true;
        }
       */
        canRoll = true;
        isRolling = false;
    }
}

