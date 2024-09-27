using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompareWeight : MonoBehaviour
{
    public int difference;
    public GameObject weightController;
    public GameObject objectPlacer;

    public static int persentage;

    public string rank;

    public static int maxWeight;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        objectPlacer = GameObject.Find("ObjectPlacer");
        maxWeight = 0;
        setMaxWeight();
        persentage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            persentage = CalculatePercentage();
        }
    }

    public int CalculatePercentage()
    {
        // 平均値を基準にする
        int averageWeight = setAveWeight();

        // 平均値が0の場合に備え、少なくとも1にする
        if (averageWeight == 0)
            averageWeight = 1;

        float scalingFactor = 0.5f;
        float matchPercentage = 100 * Mathf.Exp(-(scalingFactor * (float)difference / averageWeight));


        // 0%以下にはならないように、また100%を超えないように調整
        return (int)Mathf.Clamp(matchPercentage, 0, 100);
    }

    private void setMaxWeight()
    {
        for (int i = 0; i < ObjectPlacer.placedObjectsWeight.Length; i++)
        {
            if (ObjectPlacer.placedObjectsWeight[i] > maxWeight)
            {
                maxWeight = ObjectPlacer.placedObjectsWeight[i];
            }
        }
    }

    private int setAveWeight()
    {
        int total = 0;
        for (int i = 0; i < ObjectPlacer.placedObjectsWeight.Length; i++)
        {
            total += ObjectPlacer.placedObjectsWeight[i];
        }
        int ave = total / ObjectPlacer.placedObjectsWeight.Length;
        return ave;
    }

    public bool tooHeavyTrigger()
    {
        difference = WeightControll.weightDifference;
        if (difference != 0 && difference > maxWeight * 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
