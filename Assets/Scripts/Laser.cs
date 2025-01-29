using UnityEngine;
using Assets.Scripts.EnumTypes;


public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    GameObject player;
    public float laserLength = 30f;
    public LayerMask hitLayers;

    HpBar hpBar;
    GameObject enemy;
    EnemySoldier enemySoldier;
    Movement movement;
    Lucik lucik;
    EnemyHP enemyHP;

    private Vector3 currentDirection;

    void Start()
    {
        currentDirection = transform.up;
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        enemy = GameObject.FindGameObjectWithTag(ObjectTags.Enemy.ToString());
        hpBar = player.GetComponent<HpBar>();
        enemySoldier = enemy.GetComponent<EnemySoldier>();
        movement = player.GetComponent<Movement>();

        lucik = enemy.GetComponent<Lucik>();
        enemyHP = enemy.GetComponent<EnemyHP>();

    }

    void Update()
    {
        if (player != null)
        {
            AimLaserAtPlayer();
            FireLaser();
        }
    }

    void AimLaserAtPlayer()
    {
        Vector3 targetDirection = (player.transform.position - lineRenderer.transform.position).normalized;

        currentDirection = Vector3.Lerp(currentDirection, targetDirection, Time.deltaTime * enemySoldier.enemyRangeSpeed);
    }

    void PlayerHit(GameObject Player)
    {
        if (!movement.isRolling)
        {
            EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
            enemyProjectileDMG.OnHitDamage(enemySoldier.enemyRangeDMG);
            if (lucik.transformLucik)
            {
                if(enemyHP.currentSoldierHp < enemySoldier.maxEnemyHP)
                {
                    enemyHP.currentSoldierHp += enemySoldier.enemyRangeDMG / 2f;
                    lucik.barValue += enemySoldier.enemyRangeDMG / 1.5f;
                }
            }
        }
    }

    void FireLaser()
    {
        Vector3 startPoint = lineRenderer.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(startPoint, currentDirection, laserLength, hitLayers);

        if (hit.collider != null)
        {
            Vector3 endPoint = hit.point;

            if (hit.collider.gameObject == player && hit.collider.gameObject.name != "Lucik")
            {
                PlayerHit(player);
            }

            DrawLaser(startPoint, endPoint);
        }
        else
        {

            Vector3 endPoint = startPoint + currentDirection * laserLength;
            DrawLaser(startPoint, endPoint);
        }
    }

    void DrawLaser(Vector3 startPoint, Vector3 endPoint)
    {
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
