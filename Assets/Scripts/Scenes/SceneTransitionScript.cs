using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.EnumTypes;

public class SceneTransitionScript : MonoBehaviour
{
    private static SceneIndex activeScene;
    public GameObject endTransition;
    private bool teleport = false;
    [HideInInspector] public SceneIndex SceneFrom => activeScene;
    public SceneIndex SceneTo;
    public static SceneIndex TransitionFrom { get; private set; }
    private bool canTeleport;
    public float DistanceToTeleport = 4;
    private GameObject player;

    //Only full integers
    public int sceneChangeIndex;

    // Start is called before the first frame update

    private void Awake()
    {
        // endTransition = GameObject.FindGameObjectWithTag("endTransition");
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());

    }
    void Start()
    {
        activeScene = (SceneIndex)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        if (teleport)
        {
            TransitionFrom = SceneFrom;
            //Debug.Log(SceneTo);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: (int)SceneTo);
        }
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if(distance > DistanceToTeleport)
        {
            canTeleport = true;
        }
    }
    void EndTransition()
    {
       endTransition.SetActive(true);
    }

    IEnumerator LevelLoading()
    {
        PauseGame.canPause = false;
        yield return new WaitForSeconds(1f);
        teleport = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport)
        {
            EndTransition();
            StartCoroutine(LevelLoading());
        }
    }
}

public enum SceneIndex
{
    MainMenu = 0,
    Game = 1,
    FlowerBiome = 2,
    Swamp = 3,
    Battlefield = 4,
    MoonBiome = 5,
    Castle = 6,
    CastleInterior = 7,
    CastleInteriorEvil = 8,
    Arena = 9,
    ArenaTwo = 10,
    ArenaThree = 11,
    ArenaFour = 12,
    ArenaFive = 13,
    ArenaSix = 14,
    Shop = 15
}


