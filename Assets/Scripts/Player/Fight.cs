using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    public bool isFighting;
    public bool fightSound = false;
    public Animator animator;
    public float swordDelay;
    public bool canAttack = true;
    public Slider slider;
    public Movement movement;
    public SoundEffects sounds;
    public float swordStaminaDrain = 20;
    public float slowDown;
    public GameObject attackDown;
    public GameObject attackUp;
    public GameObject attackLeft;
    public GameObject attackRight;
    public int attackDamage;

    // Update is called once per frame
    void Update()
    {
        isFighting = Input.GetMouseButtonDown(0);
        if (isFighting && canAttack && movement.currentStamina > swordStaminaDrain && movement.isWalking)
        {
            movement.currentStamina -= swordStaminaDrain;
            Attack();
            StartCoroutine(Delay());
        }
    }

    void Attack()
    {
        if (isFighting && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("FightLeft", true);
            attackLeft.SetActive(true);
            return;

        }
        else if (isFighting && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("FightRight", true);
            attackRight.SetActive(true);
            return;

        }
        else if (isFighting && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("FightBack", true);
            attackUp.SetActive(true);
            return;
        }
        else if (isFighting && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Fight", true);
            attackDown.SetActive(true);
            return;
        }
    }

    void AttackRangeHide()
    {
        attackDown.SetActive(false);
        attackUp.SetActive(false);
        attackRight.SetActive(false);
        attackLeft.SetActive(false);
    }


    IEnumerator Delay()
    {
        canAttack = false;
        fightSound = true;
        movement.movementSpeed /= slowDown;
        yield return new WaitForSeconds(swordDelay);
        AttackRangeHide();
        canAttack = true;
        fightSound = false;
        movement.movementSpeed *= slowDown;
    }
}



