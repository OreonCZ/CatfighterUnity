using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    bool isFighting;
    public Animator animator;
    public float swordDelay;
    bool canAttack = true;
    public Slider slider;
    public Movement movement;
    public float swordStaminaDrain;
    public float slowDown;
    public GameObject attackDown;
    public GameObject attackUp;
    public GameObject attackLeft;
    public GameObject attackRight;

    // Update is called once per frame
    void Update()
    {
        isFighting = Input.GetMouseButtonDown(0);
        if (isFighting && canAttack && movement.currentStamina > 0)
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
            if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                attackUp.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                attackDown.SetActive(true);
            }
        }
        else if (isFighting && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("FightRight", true);
            attackRight.SetActive(true);
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                attackUp.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                attackDown.SetActive(true);
            }

        }
        else if (isFighting && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("FightUp", true);
            attackUp.SetActive(true);
        }
        else if (isFighting && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("FightDown", true);
            attackDown.SetActive(true);
        }
        else if (isFighting)
        {
            animator.SetBool("FightDown", true);
            attackDown.SetActive(true);
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
        movement.movementSpeed /= slowDown;
        yield return new WaitForSeconds(swordDelay);
        AttackRangeHide();
        canAttack = true;
        
        movement.movementSpeed *= slowDown;
    }
}



