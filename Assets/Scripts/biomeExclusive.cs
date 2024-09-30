using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomeExclusive : MonoBehaviour
{
    public GameObject halucinate;
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
            halucinate.SetActive(true);
        }
    }
}
