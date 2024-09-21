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
        differText.text = "ç∑ÅF " + WeightControll.weightDifference.ToString();
        rankText.text = "ÉâÉìÉNÅF " + weightController.GetComponent<CompareWeight>().rank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
