using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    public GameObject weightController;
    public Text rankText;
    public Text differText;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        differText.text = "���F " + WeightControll.weightDifference.ToString();
        rankText.text = "�҂����񂱓x�F " + weightController.GetComponent<CompareWeight>().CalculatePercentage().ToString() + " %";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
