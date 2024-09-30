using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomeExclusive1 : MonoBehaviour
{
    public GameObject halucinate2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            halucinate2.SetActive(false);
        }
    }
}
