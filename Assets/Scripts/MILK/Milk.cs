using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class Milk : MonoBehaviour
{
    HpBar hpBar;
    Animator animator;
    Movement playerMovement;
    public SoundEffects sf;
    public AudioClip drinkMilk;
    public int healMilk = 2;
    public int milkNumber;
    public int numberOfMilk;
    public int emptyMilk = 0;
    public bool canDrink = true;

    GameObject player;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        hpBar = gameObject.GetComponent<HpBar>();
        playerMovement = gameObject.GetComponent<Movement>();
        hpBar = gameObject.GetComponent<HpBar>();
        playerStats = player.GetComponent<PlayerStats>();
        playerStats.playerMilk = numberOfMilk;

        numberOfMilk = milkNumber;
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
