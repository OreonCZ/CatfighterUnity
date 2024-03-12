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
    public float mousePos;

    // Update is called once per frame
    void Update()
    {
        isFighting = Input.GetMouseButtonDown(0);
        if (isFighting && canAttack && movement.currentStamina > swordStaminaDrain && movement.isWalking)
        {
            movement.currentStamina -= swordStaminaDrain;
            Attack();
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
        if (isFighting && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("FightLeft", true);
            StartCoroutine(WaitLeft());
            return;

        }
        else if (isFighting && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("FightRight", true);
            StartCoroutine(WaitRight());
            return;

        }
        else if (isFighting && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("FightBack", true);
            StartCoroutine(WaitUp());
            return;
        }
        else if (isFighting && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Fight", true);
            StartCoroutine(WaitDown());
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



