using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public string objName;
    public int setWeight;
    public int keyNum;

    public GameObject preObj;

    public Status(int num, string name, int pWeight)
    {
        this.keyNum = num;
        this.objName = name;
        this.setWeight = pWeight;
    }
}
