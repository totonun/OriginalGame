using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRegist : MonoBehaviour
{
    //private Dictionary<GameObject, int> objectWeightDictionary;

    public List<Status> statusList;
    public List<GameObject> prefabList;

    //public List<Status> listByLevel1;
    //public List<Status> listByLevel2;
    //public List<Status> listByLevel3;

    public List<GameObject> prefabByLevel1;
    public List<GameObject> prefabByLevel2;
    public List<GameObject> prefabByLevel3;

    //public static int weightClass;

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
            //CreateStatus("ノートPC", 1800, obj),
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
            CreateStatus("アルコールランプ", 150, obj),
            CreateStatus("かじられたリンゴ", 100, obj),        
            CreateStatus("ビールケース", 18000, obj),          
            CreateStatus("カップめん", 70, obj),               // 一般的なカップ麺の重量
            CreateStatus("電工ドラム", 5000, obj),             // 中型電工ドラムの重さ
            CreateStatus("電流計", 500, obj),                  // 小型の電流計の重量
            CreateStatus("ドームカバー", 1000, obj),           // ドームカメラカバーの重量
            CreateStatus("ゲーミングPC", 8000, obj),           // ゲーミングPC本体の重量
            CreateStatus("ヒートガン", 1200, obj),             // ヒートガンの重さ
            CreateStatus("釜めしの釜", 800, obj),              // 釜めし用の釜の重量
            CreateStatus("かに缶", 150, obj),                  // 一般的なかに缶の重さ
            CreateStatus("黒板", 20000, obj),                  // 一般的な黒板の重量
            CreateStatus("くるみ割り人形", 300, obj),          // 中型のくるみ割り人形の重さ
            CreateStatus("メスフラスコ", 200, obj),            // 500mlのメスフラスコの重量
            CreateStatus("生ハム原木", 6000, obj),             // 小型の生ハム原木
            CreateStatus("日食グラス", 50, obj),               // 軽量の日食グラス
            CreateStatus("ポスト", 20000, obj),                // 一般的な街のポストの重さ
            CreateStatus("三角停止板", 1000, obj),             // 標準的な三角停止板の重さ
            CreateStatus("製麺機", 8000, obj),                 // 家庭用製麺機の重量
            CreateStatus("そろばん", 300, obj),                // 一般的なそろばんの重さ
            CreateStatus("消波ブロック", 500000, obj),         // 中型の消波ブロックの重さ
            CreateStatus("タブレット", 500, obj),              // 一般的なタブレットの重量
            CreateStatus("木製たらい", 3000, obj),             // 木製たらいの重量
            CreateStatus("手錠", 400, obj),                    // 金属製手錠の重さ
            CreateStatus("えび天丼", 500, obj),                // 一般的なえび天丼の重量
            CreateStatus("トースト", 50, obj),                 // 一枚のトーストの重さ
            CreateStatus("虎の巻", 200, obj),                  // 伝統的な虎の巻の重さ
            CreateStatus("豆腐パック", 350, obj),              // 一般的な豆腐の重さ
            CreateStatus("占いの水晶", 3000, obj),             // 中型の水晶玉の重量
            CreateStatus("ワープロ", 6000, obj),               // ワープロの平均的な重さ
            CreateStatus("ぞうきん", 100, obj)                 // 乾燥したぞうきんの重量

        };
        statusList.Sort((a, b) => string.Compare(a.objName, b.objName));

        //重さ降順に並べる
        //statusList.Sort((a, b) => b.setWeight - a.setWeight);
        
        /*
        for(int i = 0; i < statusList.Count; i++)
        {
            Debug.Log(statusList[i].setWeight + statusList[i].objName);
        }
        //Debug.Log("    ");
        */
     
        prefabArray = Resources.LoadAll<GameObject>("Prefabs");
        Regist();
        DevideByLevel();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Listに登録
    private void Regist()
    {
        
        for (int i = 0; i < prefabArray.Length; i++)
        {
            prefabList.Add(prefabArray[i]);
        }
        //prefabList.Sort((a, b) => b.GetComponent<ScrollMove>().weight - a.GetComponent<ScrollMove>().weight);
        prefabList.Sort((a, b) => string.Compare(a.name, b.name));
        //Debug.Log(prefabList.Count + " : " + statusList.Count);

        if (prefabList.Count == statusList.Count)
        {
            for (int j = 0; j < statusList.Count; j++)
            {
                statusList[j].setObject = prefabList[j];
                //Debug.Log(statusList[j].objName + " : " + prefabList[j].name);
            }
        }

    }

    public void DevideByLevel()
    {
        for(int i = 0; i < statusList.Count; i++)
        {
            int weight = statusList[i].setWeight;
            //Debug.Log(weight);
            if(weight < 400)
            {
                //listByLevel1.Add(statusList[i]);
                prefabByLevel1.Add(statusList[i].setObject);
               // weightClass = 1;
            }
            else if (weight < 9000)
            {
                //listByLevel2.Add(statusList[i]);
                prefabByLevel2.Add(statusList[i].setObject);
                //weightClass = 2;
            }
            else
            {
                //listByLevel3.Add(statusList[i]);
                prefabByLevel3.Add(statusList[i].setObject);
                //weightClass = 3;
            }
        }
        /*
        for(int j = 0; j < prefabByLevel1.Count; j++)
        {
            Debug.Log(prefabByLevel1[j].name);
        }
        */
        /*
        Debug.Log("1: " + prefabByLevel1.Count);
        Debug.Log("2: " + prefabByLevel2.Count);
        Debug.Log("3: " + prefabByLevel3.Count);
        */

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
