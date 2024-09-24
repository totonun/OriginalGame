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

    public string rank;

    //public int correction;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        difference = WeightControll.weightDifference;
        //rightWeight = WeightControll.rightSideWeight;
        //leftWeight = WeightControll.leftSideWeight;

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

    // àÍívìxçáÇ¢ÇïSï™ó¶Ç≈åvéZÇ∑ÇÈ
    public int CalculatePercentage()
    {
        int maxWeight = 0;
        for(int i = 0; i < ObjectPlacer.placedObjects.Length; i++)
        {
            if(ObjectPlacer.placedObjects[i] > maxWeight)
            {
                maxWeight = ObjectPlacer.placedObjects[i];
            }
        }

        // àÍívìxçáÇ¢ÇåvéZ
        float matchPercentage = 100 - (((float)difference / maxWeight*2) * 70);

        // 0%à»â∫Ç…ÇÕÇ»ÇÁÇ»Ç¢ÇÊÇ§Ç…í≤êÆ
        return (int)Mathf.Max(matchPercentage, 0);
    }

    /*
    void Ranking(int dif)
    {
        if(dif <= 50 * correction)
        {
            rank = "Ç∆ÇƒÇ‡Ç∑Ç≤Ç¢";
        }
        else if(dif <= 100 * correction)
        {
            rank = "ÇÌÇËÇ∆Ç∑Ç≤Ç¢";
        }
        else if(dif <= 500 * correction)
        {
            rank = "Ç‹Ç∏Ç‹Ç∏";
        }
        else if(dif <= 1000 * correction)
        {
            rank = "Ç‹Ç†Ç‹Ç†";
        }
        else if(dif <= 5000 * correction)
        {
            rank = "Ç‡Ç§ÇøÇÂÇ¢";
        }
        else if(dif <= 10000 * correction)
        {
            rank = "Ç‡Ç§ÇøÇÂÇ¢Ç™ÇÒÇŒÇÍ";
        }
        else
        {
            rank = "Ç»ÇÒÇ≈Ç‚ÇÀÇÒ";
        }
    }
    */
}
