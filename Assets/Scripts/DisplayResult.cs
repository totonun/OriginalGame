using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    public GameObject weightController;
    public Text rankText;
    public Text differText;

    public Text rightText;
    public Text leftText;
    private float rightWeight;
    private float leftWeight;
    //private float difference;

    private string unit;


    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");

        rightWeight = (float)WeightControll.rightSideWeight;
        leftWeight = (float)WeightControll.leftSideWeight;

        if (rightWeight >= 1000 && leftWeight >= 1000)
        {
            unit = " kg";
            rightWeight = (float)rightWeight / 1000;
            leftWeight = (float)leftWeight / 1000;
        }
        else
        {
            unit = " g";
        }
        //difference = Mathf.Abs(rightWeight - leftWeight);

        rightText.text = "右: " + rightWeight.ToString() + unit ;
        leftText.text = "左: " + leftWeight.ToString() + unit;


        //differText.text = "差： " + difference.ToString("N2") + unit;
        rankText.text = "ぴったんこ度： " + CompareWeight.persentage.ToString() + " %";

        if(CompareWeight.persentage > InputMaxScore.maxPersentage)
        {
            InputMaxScore.maxPersentage = CompareWeight.persentage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
