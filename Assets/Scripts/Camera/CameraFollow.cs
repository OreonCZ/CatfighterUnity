using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.EnumTypes;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    public float zoomOutStart = 40f;
    public float zoomOutEnd = 50f;
    public float zoomOffset = 4;
    public const float defaultFOV = 45f;
    public const float maxFOW = 100f;

    private Scene activeScene;
    private Camera camera;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString()).GetComponent<Transform>();
        activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        camera = GetComponent<Camera>();
        Debug.Log(activeScene.name);
        camera.fieldOfView = defaultFOV;
    }

    // Update is called once per frame
    void Update()
    {
            float playerY = player.position.y;
            transform.position = new Vector3(player.position.x, playerY, -10);
        ZoomOutAt("Battlefield", zoomOutStart, zoomOutEnd, zoomOffset);
    }

    void ZoomOutAt(string sceneName, float zoomOutStart, float zoomOutEnd, float zoomOffset)
    {
        float playerY = player.position.y;
        if (activeScene.name == sceneName && zoomOutStart < playerY)
        {
            /* 
             odecte obe hodnoty od zoomOutStart abych dostal obe hodnoty k nule. Kdyz je to nula tak se kamera hybat nebude
             */
            float t = (playerY - zoomOutStart) / (zoomOutEnd - zoomOutStart);
            camera.fieldOfView = Mathf.Lerp(defaultFOV, maxFOW, t);
            transform.position = new Vector3(player.position.x, playerY + t * zoomOffset, -10);
        }
       /* else
        {
            camera.fieldOfView = defaultFOV;
        }
       */
        
    }
}
