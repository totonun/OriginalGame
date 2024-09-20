using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareWeight : MonoBehaviour
{
    public int difference;

    public GameObject weightController;

    public string rank;

    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        difference = WeightControll.weightDifference;
        Ranking(difference);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ranking(int dif)
    {
        if(dif <= 50)
        {
            rank = "�ƂĂ�������";
        }
        else if(dif <= 100)
        {
            rank = "���Ƃ�����";
        }
        else if(dif <= 500)
        {
            rank = "�܂��܂�";
        }
        else if(dif <= 1000)
        {
            rank = "�܂��܂�";
        }
        else if(dif <= 5000)
        {
            rank = "�������傢";
        }
        else if(dif <= 10000)
        {
            rank = "�������傢����΂�";
        }
        else
        {
            rank = "�Ȃ�ł�˂�";
        }
    }

}
