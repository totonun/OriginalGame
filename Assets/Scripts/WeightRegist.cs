using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRegist : MonoBehaviour
{
    //public List<GameObject> gameObjects = new List<GameObject>(); // 管理するGameObjectのリスト
    //public List<int> weights = new List<int>();            // それに対応する重さのリスト

    private Dictionary<GameObject, int> objectWeightDictionary;

    public List<Status> statusList;

    // Start is called before the first frame update
    void Start()
    {
        //ObjectAddList();
        Regist();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void ObjectAddList()
    {
        // ResourcesフォルダからPrefabをロードして追加

        //GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs");

        for (int i = 0; i < objs.Length; i++)
        {
            if (objs != null)
            {
                //gameObjects.Add(objs[i]);
                //weights.Add(objs[i].GetComponent<Weight>().weight);
            }
        }
    }
    */
    void Regist()
    {
        statusList = new()
        {
            new Status(1, "Apple", 180),
            new Status(2, "Banana", 120),
            new Status(3, "Cat", 4000),
            new Status(4, "Deer", 60000),
            new Status(5, "Horse", 500000),
            new Status(6, "Milk", 1000),
            new Status(7, "PC", 1800),
        };
    }
}
