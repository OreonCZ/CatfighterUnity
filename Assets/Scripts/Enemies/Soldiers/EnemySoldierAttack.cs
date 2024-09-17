using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierAttack : MonoBehaviour
{
    EnemySoldierMoving parentSoldier;
    // Start is called before the first frame update
    void Start()
    {
        parentSoldier = gameObject.transform.parent.gameObject.GetComponent<EnemySoldierMoving>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == ObjectTags.Player.ToString())
        {
            parentSoldier.isFollowing = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ObjectTags.Player.ToString())
        {
            parentSoldier.isFollowing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
