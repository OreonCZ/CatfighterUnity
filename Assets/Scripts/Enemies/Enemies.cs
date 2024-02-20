using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[CreateAssetMenuAttribute(fileName = "Enemy", menuName = "Enemy/Create new enemy")]
public class Enemies : ScriptableObject
{
    public string catName;
    public int maxEnemyHp;
    public int enemyDamage;
    public float enemySpeed;
    public float enemyAttackCooldown;
    public float fireRate;
    public int shootDamage;
    public float fireSpeed;
    public float destroyProjectile;
}
