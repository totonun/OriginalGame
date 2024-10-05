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

    private bool isTextInput;

    public GameObject itemController;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {      
        if(SceneManager.GetActiveScene().name == "Result" || SceneManager.GetActiveScene().name == "Main")
        {
            TextInput(rightWeightText, rightSideWeight);
            TextInput(leftWeightText, leftSideWeight);
            //CompareWeight();
        }
        isTextInput = false;

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemController.GetComponent<ItemControll>().itemUsed)
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
        //compareTrigger = true;
        //rightWeightText.text = rightSideWeight.ToString();
        audioSource.Play();
        CompareWeight();
    }

    public void LeftAddWeight(int j)
    {
        leftSideWeight += j;
        TextInput(leftWeightText, leftSideWeight);
        audioSource.Play();
        CompareWeight();
    }

    void CompareWeight()
    {
        weightDifference = Mathf.Abs(rightSideWeight - leftSideWeight);
        //Debug.Log(rightSideWeight + " : " +  leftSideWeight);
        Debug.Log("Difference: " + weightDifference);
    } 

    void TextInput(Text pText, int pWeight)
    {
        pText.text = pWeight.ToString();
    }

}
