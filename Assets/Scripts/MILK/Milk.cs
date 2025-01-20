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
    SoundEffects sf;
    public AudioClip drinkMilk;
    float healMilk;
    public float numberOfMilk;
    float emptyMilk = 0;
    public bool canDrink = true;
    GameObject camera;

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
        animator = GetComponent<Animator>();
        camera = GameObject.FindGameObjectWithTag(ObjectTags.MainCamera.ToString());
        sf = camera.GetComponent<SoundEffects>();

        numberOfMilk = playerStats.playerMilk;
        healMilk = (playerStats.playerMaxHP / 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !playerMovement.isWalking && canDrink && !playerMovement.isRolling)
        {
            if(emptyMilk < playerStats.playerMilk)
            {
                StartCoroutine(DrinkCooldown());
                Drink();
            }
        }
    }

    void Drink() {
        if (hpBar.currentHp < playerStats.playerMaxHP && (hpBar.currentHp + healMilk) < playerStats.playerMaxHP)
        {
            hpBar.currentHp += healMilk;
            sf.audio.clip = drinkMilk;
            sf.audio.Play();
            animator.SetTrigger("Drink");
            //Debug.Log("Aktualni zivoty: " + hpBar.currentHp);
            emptyMilk+=1f;
            Debug.Log("Vypito mlika: " + emptyMilk);
            numberOfMilk -= 1;
            Debug.Log("emptu milk " + emptyMilk);
        }
    }
    IEnumerator DrinkCooldown()
    {
        canDrink = false;
        yield return new WaitForSeconds(1);
        canDrink = true;
    }
}
