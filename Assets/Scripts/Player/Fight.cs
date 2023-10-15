using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    bool isFighting;
    public Animator animator;
    public float swordDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isFighting = Input.GetMouseButtonDown(0);
        if (isFighting)
        {
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
        Attack();

        yield return new WaitForSeconds(swordDelay);
    }
}
