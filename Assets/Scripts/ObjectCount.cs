using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCount : MonoBehaviour
{
    private int[] objectCountArray;
    private string[] objectNames;
    //public GameObject weightRegister;
    private GameObject objectPlacer;
    //private GameObject[] placedObjects;
    private GameObject[] objectsOnCanvas;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //weightRegister = GameObject.Find("WeightRegister");
        //int n= weightRegister.GetComponent<WeightRegist>().statusList.Count;

        objectPlacer = GameObject.Find("ObjectPlacer");
        count = objectPlacer.GetComponent<ObjectPlacer>().count;
        objectCountArray = new int[count];
        //objectNames = this.gameObject.GetComponent<ObjectPlacer>().objectNames;
        objectNames = ObjectPlacer.objectNames;
        //placedObjects = objectPlacer.GetComponent<ObjectPlacer>().placedObjects;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacedObjectCount(string pName)
    {
        for(int i = 0; i < count; i++)
        {
            if (objectNames[i] == pName)
            {
                objectCountArray[i]++;
            }
        }
    }

    public bool differenceTrigger()
    {
        GameObject[] rightSideObjects = GameObject.FindGameObjectsWithTag("Right");
        GameObject[] leftSideObjects = GameObject.FindGameObjectsWithTag("Left");
        int difference = Mathf.Abs(rightSideObjects.Length - leftSideObjects.Length);
        if(difference != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkUseObject()
    {
        bool check = true; 

        for(int i = 0; i < count; i++)
        {
            if(objectCountArray[i] == 0)
            {
                check = false;
            }
        }

        return check;
    }
}
