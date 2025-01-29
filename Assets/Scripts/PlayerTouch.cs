using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.SceneManagement;

public class PlayerTouch : MonoBehaviour
{
    GameObject actButton;
    // Start is called before the first frame update
    private void Awake()
    {
        actButton = GameObject.Find("buttonF");
    }

    void Start()
    {
        actButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTags.Player.ToString()))
        {
            actButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(sceneBuildIndex: 15);
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTags.Player.ToString()))
        {
            actButton.SetActive(false);
        }
    }
}
