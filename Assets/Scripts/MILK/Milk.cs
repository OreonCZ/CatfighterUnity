using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Milk : MonoBehaviour
{
    public HpBar hpBar;
    public Animator animator;
    public Movement playerMovement;
    public SoundEffects sf;
    public AudioClip drinkMilk;
    public int healMilk = 1;
    public int milkNumber = 3;
    public int numberOfMilk = 3;
    public int emptyMilk = 0;
    public bool canDrink = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !playerMovement.isWalking && emptyMilk < milkNumber && canDrink && !playerMovement.isRolling)
        {
            StartCoroutine(DrinkCooldown());
            Drink();
        }
    }

    void Drink() {
        if (hpBar.currentHp < hpBar.maxHp)
        {
            hpBar.currentHp += healMilk;
            sf.audio.clip = drinkMilk;
            sf.audio.Play();
            animator.SetTrigger("Drink");
            Debug.Log("Aktualni zivoty: " + hpBar.currentHp);
            emptyMilk++;
            Debug.Log("Vypito mlika: " + emptyMilk);
            numberOfMilk -= 1;
        }
    }
    IEnumerator DrinkCooldown()
    {
        canDrink = false;
        yield return new WaitForSeconds(1);
        canDrink = true;
    }
}
