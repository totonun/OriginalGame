using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRegist : MonoBehaviour
{
    //public List<GameObject> gameObjects = new List<GameObject>(); // 管理するGameObjectのリスト
    //public List<int> weights = new List<int>();            // それに対応する重さのリスト

    private Dictionary<GameObject, int> objectWeightDictionary;

    public List<Status> statusList;
    public List<GameObject> prefabList;

    private GameObject obj = null;

    public GameObject[] prefabArray;

    // Start is called before the first frame update
    private void Awake()
    {
        statusList = new List<Status>
        {
            CreateStatus("りんご", 180, obj),
            CreateStatus("バナナ", 120, obj),
            CreateStatus("ねこ", 4000, obj),
            CreateStatus("しか", 60000, obj),
            CreateStatus("うま", 500000, obj),
            CreateStatus("牛乳(ビン)", 1000, obj),
            CreateStatus("ノートPC", 1800, obj),
            CreateStatus("アルパカ", 60000, obj),
            CreateStatus("アライグマ", 6000, obj),
            CreateStatus("ホッキョクグマ(メス)", 200000, obj),
            CreateStatus("エビフライ", 30, obj),
            CreateStatus("ゴマフアザラシ", 100000, obj),
            CreateStatus("ヘラジカ", 450000, obj),
            CreateStatus("黒毛和牛", 600000, obj),
            CreateStatus("レッサーパンダ", 45000, obj),
            CreateStatus("モルモット", 10000, obj),
            CreateStatus("モモンガ", 120, obj),
            CreateStatus("もやし(1本)", 2, obj),
            CreateStatus("パンダ", 120000, obj),
            CreateStatus("プテラノドン", 15000, obj),
            CreateStatus("タケノコ(小さめ)", 10000, obj),
            CreateStatus("生まれたての子鹿", 50000, obj),
        };
        statusList.Sort((a, b) => string.Compare(a.objName, b.objName));

        prefabArray = Resources.LoadAll<GameObject>("Prefabs");
        Regist();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Listに登録
    void Regist()
    {

        //Listに登録
        for (int i = 0; i < prefabArray.Length; i++)
        {
            prefabList.Add(prefabArray[i]);
        }
        if (prefabList.Count == statusList.Count)
        {
            for (int j = 0; j < statusList.Count; j++)
            {
                statusList[j].setObject = prefabList[j];
            }
        }

    }

    Status CreateStatus(string name, int weight, GameObject obj)
    {
        Status status = ScriptableObject.CreateInstance<Status>();
        status.Initialize(name, weight, obj);
        return status;
    }

    //リストから参照して同じ名前のものの重さを返す
    public int weightReturn(GameObject pObject)
    {
        int pWeight = 0;

        for(int i = 0; i < statusList.Count; i++) { 
       
            if(statusList[i].objName == pObject.name)
            {
                pWeight = statusList[i].setWeight;
            }
        }
        return pWeight;
    }

}
