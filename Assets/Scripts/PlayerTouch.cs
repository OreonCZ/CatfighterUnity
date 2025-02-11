using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.SceneManagement;

public class PlayerTouch : MonoBehaviour
{
    GameObject actButton;
    public GameObject endTransition;
    // Start is called before the first frame update
    private void Awake()
    {
        actButton = gameObject.transform.GetChild(0).gameObject;
    }

    void Start()
    {
        actButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DiffBuildings(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(gameObject.CompareTag(ObjectTags.Shop.ToString()))
        {
            SceneManager.LoadScene(sceneBuildIndex: 15);
        }
        if(gameObject.CompareTag(ObjectTags.Box.ToString()))
        {
            SceneManager.LoadScene(sceneBuildIndex: 19);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTags.Player.ToString()))
        {
            actButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                endTransition.SetActive(true);
                StartCoroutine(DiffBuildings(1f));
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTags.Player.ToString()))
        {
            actButton.SetActive(false);
        }
    }
}
