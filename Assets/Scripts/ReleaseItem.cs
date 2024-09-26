using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseItem : MonoBehaviour
{
    public int randomRangeNum;
    private int randomNum;
    public static bool isItem;

    private void Awake()
    {
        randomNum = 0;
        isItem = false;

        switch (DifficultySet.levelNum)
        {
            case 0:
                randomRangeNum = 2;
                break;
            case 1:
                randomRangeNum = 4;
                break;
            case 2:
                randomRangeNum = 6;
                break;
            case 3:
                randomRangeNum = 8;
                break;
            case 4:
                randomRangeNum = 10;
                break;
        }

        randomNum = Random.Range(0, randomRangeNum);
        Debug.Log("RandomNum: " + randomNum + "RandomRange" + randomRangeNum);
        if (randomNum == 0)
        {
            isItem = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
