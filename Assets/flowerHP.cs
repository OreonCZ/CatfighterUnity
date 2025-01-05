using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.UI;

public class flowerHP : MonoBehaviour
{
    EnemySoldier enemySoldier;
    public GameObject enemyHpBar;
    public Slider enemyHpSlider;
    [HideInInspector] public float currentSoldierHp;
    public bool isDefeated = false;
    public bool isKilled = false;

    ParticleSystem particleSystem;

    // Start is called before the first frame update

    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();

        currentSoldierHp = enemySoldier.maxEnemyHP;
        enemyHpSlider.maxValue = enemySoldier.maxEnemyHP;

        particleSystem = GetComponentInChildren<ParticleSystem>();

        //enemySoldier.EnemyAttackDiff(enemySoldierAttack, enemyRangerAttack, enemyBulletAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHpSlider != null)
        {
            enemyHpSlider.value = currentSoldierHp;
        }
        if (currentSoldierHp <= 0)
        {
            StartCoroutine(DestroyFlower());
        }
        IEnumerator DestroyFlower()
        {
            particleSystem.Play();
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }

   
}

