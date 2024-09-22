using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareWeight : MonoBehaviour
{
    public int difference;

    public GameObject weightController;

    public string rank;

    public int correction;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        difference = WeightControll.weightDifference;
        Ranking(difference);

        int weightClass = weightController.GetComponent<WeightRegist>().weightClass;
        switch (weightClass)
        {
            case 1:
                correction = 1;
                break;
            case 2:
                correction = 10;
                break;
            case 3:
                correction = 100;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ranking(int dif)
    {
        if(dif <= 50 * correction)
        {
            rank = "とてもすごい";
        }
        else if(dif <= 100 * correction)
        {
            rank = "わりとすごい";
        }
        else if(dif <= 500 * correction)
        {
            rank = "まずまず";
        }
        else if(dif <= 1000 * correction)
        {
            rank = "まあまあ";
        }
        else if(dif <= 5000 * correction)
        {
            rank = "もうちょい";
        }
        else if(dif <= 10000 * correction)
        {
            rank = "もうちょいがんばれ";
        }
        else
        {
            rank = "なんでやねん";
        }
    }

}
