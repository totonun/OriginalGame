using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySet : MonoBehaviour
{
    public static int playCount;
    public int level;
    public string levelWord;
    public Text playCountText;
    public Text levelText;

    public GameObject gameManager;
    public float timer; 

    // Start is called before the first frame update
    void Start()
    {
        playCount++;
        playCountText.text = "プレイ回数: " + playCount;
        level = gameLevel(playCount);

        levelToWord(level);
        levelText.text = levelWord;

        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<TimeControll>().timer = timer;
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    
    int gameLevel(int n)
    {
        int pLevel = 0;
        switch(n)
        {
            case 1:
                pLevel = 0;
                break;
            case 2:
                pLevel = 1;
                break;
            case 3:
                pLevel = 1;
                break;
            case 4:
                pLevel = 2;
                break;
            case 5:
                pLevel = 2;
                break;
            case 6:
                pLevel = 2;
                break;
            case 7:
                pLevel = 3;
                break;
            case 8:
                pLevel = 3;
                break;
            case 9:
                pLevel = 3;
                break;
            case 10:
                pLevel = 3;
                break;
            case 11:
                pLevel = 4;
                break;
            case 12:
                pLevel = 4;
                break;
            case 13:
                pLevel = 4;
                break;
            case 14:
                pLevel = 4;
                break;
            case 15:
                pLevel = 4;
                break;
        }

        return pLevel;
    }

    void levelToWord(int pLevel)
    {
        switch (pLevel)
        {
            case 0:
                levelWord = "チャートリアル";
                timer = 20;
                break;
            case 1:
                levelWord = "ひよっこモード";
                timer = 20;
                break;
            case 2:
                levelWord = "ぼちぼちモード";
                timer = 15;
                break;
            case 3:
                levelWord = "チャレンジモード";
                timer = 15;
                break;
            case 4:
                levelWord = "あせあせモード";
                timer = 10;
                break;
        }
    }
}
