using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareWeight : MonoBehaviour
{
    public GameObject[] objects = new GameObject[2];
    public int[] weight = new int[2];
    public int leftSideWeight;
    public int rightSideWeight;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objects.Length; i++) {
            //Debug.Log(objects[i]);
            //Debug.Log((i + 1) + " :" + weight[i]);
        }
        weight[0] = 150;
        weight[1] = 500;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leftSideInput(int n)
    {
        leftSideWeight += weight[n];
    }
}
