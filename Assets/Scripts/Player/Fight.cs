using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class Fight : MonoBehaviour
{
    public bool isFighting;
    public bool fightSound = false;
    public Animator animator;
    float swordDelay = 0.5f;
    public bool canAttack = true;
    public Slider slider;
    public Movement movement;
    public SoundEffects sounds;
    float swordStaminaDrain;
    float slowDown = 2f;
    public GameObject attackDown;
    public GameObject attackUp;
    public GameObject attackLeft;
    public GameObject attackRight;
    [HideInInspector] public float attackDamage;

    GameObject player;
    PlayerStats playerStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();
        attackDamage = playerStats.playerDamage;
        swordStaminaDrain = (playerStats.playerMaxStamina / 4);
    }
    // Update is called once per frame
    void Update()
    {
        isFighting = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        if (isFighting && canAttack && movement.currentStamina > swordStaminaDrain && !movement.isRolling)
        {
            movement.currentStamina -= swordStaminaDrain;
            if (Input.GetKey(KeyCode.D)){
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    KickAttackLeft();
                }
                else
                {
                    Attack();
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    KickAttackRight();
                }
                else
                {
                    Attack();
                }
            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    KickAttack();
                }
                else
                {
                    Attack();
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.UpArrow)) {
                    KickAttackBack();
                }
                else
                {
                    Attack();
                }
            }
            else
            {
                Attack();
            }

            
            StartCoroutine(Delay());
           /* Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
                Debug.Log(player.position);
            }
           */
        }
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("FightLeft", true);
            fightSound = true;
            StartCoroutine(WaitLeft());
            return;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("FightRight", true);
            fightSound = true;
            StartCoroutine(WaitRight());
            return;

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("FightBack", true);
            fightSound = true;
            StartCoroutine(WaitUp());
            return;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Fight", true);
            fightSound = true;
            StartCoroutine(WaitDown());
            return;
        }
        
    }
    void KickAttackLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("KickLeft", true);
            fightSound = true;
            StartCoroutine(WaitLeft());
            return;

        }
    }
    void KickAttackRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("KickRight", true);
            fightSound = true;
            StartCoroutine(WaitRight());
            return;

        }
    }
    void KickAttack()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Kick", true);
            fightSound = true;
            StartCoroutine(WaitDown());
            return;

        }
    }
    void KickAttackBack()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("KickBack", true);
            fightSound = true;
            StartCoroutine(WaitUp());
            return;

        }
    }

    void AttackRangeHide()
    {
        attackDown.SetActive(false);
        attackUp.SetActive(false);
        attackRight.SetActive(false);
        attackLeft.SetActive(false);
        fightSound = false;
    }


    IEnumerator Delay()
    {
        canAttack = false;
        movement.movementSpeed /= slowDown;
        yield return new WaitForSeconds(swordDelay);
        AttackRangeHide();
        canAttack = true;
        movement.movementSpeed *= slowDown;
    }
    IEnumerator WaitLeft()
    {
        yield return new WaitForSeconds(0.2f);
        attackLeft.SetActive(true);
    }
    IEnumerator WaitUp()
    {
        yield return new WaitForSeconds(0.2f);
        attackUp.SetActive(true);
    }
    IEnumerator WaitRight()
    {
        yield return new WaitForSeconds(0.2f);
        attackRight.SetActive(true);
    }
    IEnumerator WaitDown()
    {
        yield return new WaitForSeconds(0.2f);
        attackDown.SetActive(true);
    }
    }
        




