using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class SafeArea : MonoBehaviour
{
    public static bool inArea = false;
    Camera camera;

    public float colorChangeSpeed = 1f;
    public Color safeColor = Color.blue;
    public float maxLerpValue = 1f;
    public float damageCooldown = 1f;

    private Color originalColor;
    private float lerpValue = 0f;
    private float damageTimer = 0f;

    EnemySoldier enemySoldier;
    HpBar hpBar;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag(ObjectTags.MainCamera.ToString()).GetComponent<Camera>();
        enemySoldier = GameObject.Find("Luna").GetComponent<EnemySoldier>();
        hpBar = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString()).GetComponent<HpBar>();
    }

    void Update()
    {
        if (inArea)
        {
            lerpValue = Mathf.Clamp01(lerpValue + Time.deltaTime * colorChangeSpeed);
            camera.backgroundColor = Color.Lerp(originalColor, safeColor, lerpValue);
        }
        else
        {
            lerpValue = Mathf.Clamp01(lerpValue - Time.deltaTime * colorChangeSpeed);
            camera.backgroundColor = Color.Lerp(originalColor, safeColor, lerpValue);

            if (lerpValue <= 0f)
            {
                damageTimer += Time.deltaTime;
                if (damageTimer >= damageCooldown)
                {
                    DealDamageToPlayer();
                    damageTimer = 0f;
                }
            }
        }
    }

    private void DealDamageToPlayer()
    {
        hpBar.currentHp -= enemySoldier.enemyDMG;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ObjectTags.Player.ToString()))
        {
            inArea = true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ObjectTags.Player.ToString()))
        {
            inArea = false;
        }
    }
}
