using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using System.Linq;
using UnityEngine.SceneManagement;

public class playerSpawnScript : MonoBehaviour
{
    private GameObject[] wallTeleports;
    //private SceneIndex activeSceneIndex;

    private void Awake()
    {
        wallTeleports = GameObject.FindGameObjectsWithTag(ObjectTags.sceneSwitch.ToString());
       //activeSceneIndex = (SceneIndex)SceneManager.GetActiveScene().buildIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        //SceneTransitionScript currentTransition = SceneTransitionScript.TransitionFrom;
        GameObject teleportTo = wallTeleports
            .Where(teleport => 
                teleport.GetComponent<SceneTransitionScript>().SceneTo == SceneTransitionScript.TransitionFrom
            ).FirstOrDefault();
        if(teleportTo is not null)
        {
            GridLayout grid = teleportTo.transform.gameObject.GetComponent<GridLayout>();
            Vector3 position = teleportTo.transform.position;
            Debug.Log($"Position: {position} | teleport count: {wallTeleports.Length}");
            transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
