using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCount : MonoBehaviour
{
    private int[] objectCountArray;
    private string[] objectNames;
    private GameObject objectPlacer;
    private GameObject[] objectsOnCanvas;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        objectPlacer = GameObject.Find("ObjectPlacer");
        count = objectPlacer.GetComponent<ObjectPlacer>().count;
        objectCountArray = new int[count];
        objectNames = ObjectPlacer.objectNames;
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
