using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeightControll : MonoBehaviour
{
    public static int leftSideWeight = 0;
    public static int rightSideWeight = 0;
    public int weightDifference;

    public Text rightWeightText;
    public Text leftWeightText;


    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Result")
        {
            TextInput(rightWeightText, rightSideWeight);
            TextInput(leftWeightText, leftSideWeight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("RightWeight:" + rightSideWeight);
        //Debug.Log(leftWeightText.text);
    }

    public void RightAddWeight(int i)
    {
        rightSideWeight += i;
        //Debug.Log("Weight: " + rightSideWeight);
        TextInput(rightWeightText, rightSideWeight);
        rightWeightText.text = rightSideWeight.ToString();
    }

    public void LeftAddWeight(int j)
    {
        leftSideWeight += j;
        //Debug.Log("Weight: " + leftSideWeight);
        leftWeightText.text = leftSideWeight.ToString();
        TextInput(leftWeightText, leftSideWeight);
    }

    void CompareWeight()
    {
        weightDifference = Mathf.Abs(rightSideWeight - leftSideWeight);
        //Debug.Log("ç∑ÅF" + weightDifference);
    }

    void TextInput(Text pText, int pWeight)
    {
        pText.text = pWeight.ToString();
    }

}
