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
        }
        else if (isFighting && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("FightRight", true);
        }
        else if (isFighting && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("FightUp", true);
        }
        else if (isFighting && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("FightDown", true);
        }
        else if (isFighting)
        {
            animator.SetBool("FightDown", true);
        }
    }

    IEnumerator Delay()
    {
        canAttack = false;
        yield return new WaitForSeconds(swordDelay);
        canAttack = true;
    }
}



