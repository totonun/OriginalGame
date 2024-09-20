using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : ScriptableObject
{
    public string objName;
    public int setWeight;
    public GameObject setObject;

    public GameObject preObj;

    public void Initialize(string pName, int pWeight, GameObject pObject)
    {
        this.objName = pName;
        this.setWeight = pWeight;
        this.setObject = pObject;
    }
}
