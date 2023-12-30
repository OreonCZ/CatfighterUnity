using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[CreateAssetMenuAttribute(fileName = "Enemy", menuName = "Enemy/Create new enemy")]
public class Enemies : ScriptableObject
{
    [SerializeField] string catName;

    [SerializeField] Sprite walkLeft1;
    [SerializeField] Sprite walkLeft2;
    [SerializeField] Sprite walkLeft3;
    [SerializeField] Sprite walkRight1;
    [SerializeField] Sprite walkRight2;
    [SerializeField] Sprite walkRight3;

    public int maxEnemyHp;
    public int currentEnemyHp;
    public int enemyDamage;
    public int enemySpeed;
}
