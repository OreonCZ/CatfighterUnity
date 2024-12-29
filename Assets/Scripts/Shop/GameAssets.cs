using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load("GameAssets") as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }
    public Sprite sword1;
    public Sprite sword2;
    public Sprite sword3;
    public Sprite sword4;
    public Sprite heart1;
    public Sprite heart2;
    public Sprite heart3;
    public Sprite heart4;
    public Sprite milk1;
    public Sprite milk2;
    public Sprite milk3;
    public Sprite milk4;
    public Sprite speed1;
    public Sprite speed2;
    public Sprite speed3;
    public Sprite speed4;
    public Sprite fish;
    public Sprite stamina1;
    public Sprite stamina2;
    public Sprite stamina3;
    public Sprite stamina4;
    public Sprite gear;
    public Sprite ball;
}
