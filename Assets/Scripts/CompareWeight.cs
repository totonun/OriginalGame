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

    public static int persentage;

    public string rank;

    //public int correction;

    public static int maxWeight;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        objectPlacer = GameObject.Find("ObjectPlacer");
        //rightWeight = WeightControll.rightSideWeight;
        //leftWeight = WeightControll.leftSideWeight;
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

    /*
       public int CalculatePercentage()
       {
           // ��v�x�������v�Z
           float matchPercentage = 100 - (((float)difference / maxWeight *4) * 60);
           Debug.Log(((float)difference / maxWeight * 7) * 60);

           // 0%�ȉ��ɂ͂Ȃ�Ȃ��悤�ɒ���
           return (int)Mathf.Max(matchPercentage, 0);
       }
    */
    public int CalculatePercentage()
    {
        // ���ϒl����ɂ���
        int averageWeight = setAveWeight();

        // ���ϒl��0�̏ꍇ�ɔ����A���Ȃ��Ƃ�1�ɂ���
        if (averageWeight == 0)
            averageWeight = 1;

        float scalingFactor = 0.5f;
        float matchPercentage = 100 * Mathf.Exp(-(scalingFactor * (float)difference / averageWeight));


        // 0%�ȉ��ɂ͂Ȃ�Ȃ��悤�ɁA�܂�100%�𒴂��Ȃ��悤�ɒ���
        return (int)Mathf.Clamp(matchPercentage, 0, 100);
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
}
