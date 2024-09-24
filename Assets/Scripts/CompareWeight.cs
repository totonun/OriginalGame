using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompareWeight : MonoBehaviour
{
    public int difference;
    //public int rightWeight;
   // public int leftWeight;

    public GameObject weightController;
    public GameObject objectPlacer;

    public string rank;

    //public int correction;

    public int maxWeight;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        //objectPlacer = GameObject.Find("ObjectPlacer");
        //rightWeight = WeightControll.rightSideWeight;
        //leftWeight = WeightControll.leftSideWeight;
        maxWeight = 0;
        setMaxWeight();

        /*
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
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(SceneManager.GetActiveScene().name == "Result")
        {
            Debug.Log(CalculatePercentage());
        }
        */
    }

    // 一致度合いを百分率で計算する
    public int CalculatePercentage()
    {
        // 一致度合いを計算
        float matchPercentage = 100 - (((float)difference / maxWeight *2) * 70);

        // 0%以下にはならないように調整
        return (int)Mathf.Max(matchPercentage, 0);
    }

    private void setMaxWeight()
    {
        for (int i = 0; i < ObjectPlacer.placedObjectsWeight.Length; i++)
        {
            //Debug.Log(ObjectPlacer.placedObjectsWeight[i]);
            if (ObjectPlacer.placedObjectsWeight[i] > maxWeight)
            {
                maxWeight = ObjectPlacer.placedObjectsWeight[i];
                //Debug.Log("Added");
            }
        }
    }

    public bool tooHeavyTrigger()
    {
        difference = WeightControll.weightDifference;
        //Debug.Log(difference + " : " + maxWeight);
        if (difference > maxWeight * 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
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
    */
}
