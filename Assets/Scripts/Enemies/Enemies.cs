using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[CreateAssetMenuAttribute(fileName = "Enemy", menuName = "Enemy/Create new enemy")]
public class Enemies : ScriptableObject
{
    public string catName;
    public float maxEnemyHp;
    public float enemyDamage;
    public float enemySpeed;
    public float enemyAttackCooldown;
    public float fireRate;
    public float shootDamage;
    public float fireSpeed;
    public float destroyProjectile;
    public int catLevel;
    public bool isBoss;
    public bool isRanger;
    public bool isMelee;
    public bool teleporingEnemy;
    public bool isTurret;
}
