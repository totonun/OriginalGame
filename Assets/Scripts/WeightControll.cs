using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeightControll : MonoBehaviour
{
    public static int leftSideWeight = 0;
    public static int rightSideWeight = 0;
    public static int weightDifference = 0;

    public Text rightWeightText;
    public Text leftWeightText;

    private bool compareTrigger;
    private bool isTextInput;

    public GameObject itemController;


    // Start is called before the first frame update
    void Start()
    {      
        if(SceneManager.GetActiveScene().name == "Result" || SceneManager.GetActiveScene().name == "Main")
        {
            TextInput(rightWeightText, rightSideWeight);
            TextInput(leftWeightText, leftSideWeight);
            CompareWeight();
        }
        isTextInput = false;
        compareTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (compareTrigger)
        {
            CompareWeight();
            compareTrigger = false;
        }
        else if (itemController.GetComponent<ItemControll>().itemUsed)
        {
            BothTextInput();
        }
    }

    private void BothTextInput()
    {
        if (!isTextInput)
        {
            TextInput(rightWeightText, rightSideWeight);
            TextInput(leftWeightText, leftSideWeight);
            isTextInput = true;
        }
    }

    public void RightAddWeight(int i)
    {
        rightSideWeight += i;
        TextInput(rightWeightText, rightSideWeight);
        compareTrigger = true;
        //rightWeightText.text = rightSideWeight.ToString();
    }

    public void LeftAddWeight(int j)
    {
        leftSideWeight += j;
        //leftWeightText.text = leftSideWeight.ToString();
        compareTrigger = true;
        TextInput(leftWeightText, leftSideWeight);
    }

    void CompareWeight()
    {
        weightDifference = Mathf.Abs(rightSideWeight - leftSideWeight);
    }

    void TextInput(Text pText, int pWeight)
    {
        pText.text = pWeight.ToString();
    }

}
