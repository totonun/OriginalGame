using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacer : MonoBehaviour
{
    public List<GameObject> objectsToPlace; // 配置するオブジェクトのリスト
    public GameObject[] objectToPlaceArray;
    public static int[] placedObjects; //配置されたオブジェクトの重さ
    public Transform[] positions; // 配置する位置の配列
    public Text[] texts;
    public string[] objectNames;

    public GameObject canvas;
    private GameObject weightController;
    private GameObject gameManager;

    RectTransform rectTransform;
    public Vector3[] textPos;

    public int[] instancedNumbers;

    //public int instantiateCount;

    public int count;

    private void Awake()
    {
        weightController = GameObject.Find("WeightController");
        int listSelect = Random.Range(1, 4);
        Debug.Log("RandomSelect: " + listSelect);

        switch (listSelect)
        {
            case 1:
                objectsToPlace = weightController.GetComponent<WeightRegist>().prefabByLevel1;
                /*
                for(int i = 0; i < objectsToPlace.Count; i++)
                {
                    Debug.Log(objectsToPlace[i].name);
                }
                */
                break;
            case 2:
                objectsToPlace = weightController.GetComponent<WeightRegist>().prefabByLevel2;
                break;
            case 3:
                objectsToPlace = weightController.GetComponent<WeightRegist>().prefabByLevel3;
                break;
        }
        //objectsToPlace = weightController.GetComponent<WeightRegist>().prefabList;

        count = Mathf.Min(objectsToPlace.Count, positions.Length); // 小さい方の要素数をcountに代入する
        objectNames = new string[count];

        objectToPlaceArray = new GameObject[objectsToPlace.Count];
        for(int i = 0; i < objectToPlaceArray.Length; i++)
        {
            objectToPlaceArray[i] = objectsToPlace[i];
        }

        placedObjects = new int[count];
    }

    // Start is called before the first frame update
    void Start()
    {
        // 配置場所のインデックスをランダムにシャッフル
        ShuffleArray(positions);

        //  Prefabが存在するオブジェクトの数が要素数の配列
        int num = objectsToPlace.Count;
        instancedNumbers = new int[num];

        //instantiateCount = 0;

        rectTransform = GetComponent<RectTransform>();

        /*
        textPos = new Vector3[texts.Length];

        for (int i = 0; i < texts.Length; i++)
        {
            textPos[i] = new Vector3(texts[i].rectTransform.position.x, texts[i].rectTransform.position.y, 0);
        }
        */

        PlaceObjectsRandomly();

        gameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // オブジェクトをランダムに配置するメソッド
    void PlaceObjectsRandomly()
    {

        bool[] usedObjects = new bool[objectsToPlace.Count]; // オブジェクトが使用されたかを追跡する配列

        for (int i = 0; i < count; i++)
        {
            // 使用されていないオブジェクトをランダムに選ぶ
            int randomIndex = Random.Range(0, objectsToPlace.Count);

            // 無限ループ回避のためのカウンター
            int attempts = 0;
            int maxAttempts = objectsToPlace.Count * 2; // 最大試行回数を設定

            // 使用済みのオブジェクトが選ばれている場合は選び直す
            while (usedObjects[randomIndex] && attempts < maxAttempts)
            {
                randomIndex = Random.Range(0, objectsToPlace.Count);
                attempts++;
            }

            // すべてのオブジェクトが使用済みならループを抜ける
            if (attempts >= maxAttempts) break;

            // 選ばれたオブジェクトをランダムな位置に配置する
            GameObject newObject = Instantiate(objectsToPlace[randomIndex]);
            newObject.name = objectsToPlace[randomIndex].name;
            objectNames[i] = newObject.name;

            newObject.GetComponent<ScrollMove>().weight = weightController.GetComponent<WeightRegist>().weightReturn(newObject);
            placedObjects[i] = newObject.GetComponent<ScrollMove>().weight;

           texts[i].text = newObject.name;
            texts[i].rectTransform.position = new Vector3(positions[i].position.x, positions[i].transform.position.y + 60, 0);

            // オブジェクトを使用済みにマークする
            usedObjects[randomIndex] = true;

        // 新しいオブジェクトをCanvasの子に設定
        newObject.transform.SetParent(canvas.transform, false);

            // newObjectのRectTransformを取得して、positionの値を設定
            rectTransform = newObject.GetComponent<RectTransform>();

            // ローカル座標系に変換して設定する
            rectTransform.anchoredPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(positions[i].position);

            // 新しく生成されたオブジェクトをアクティブにする
            newObject.SetActive(true);

            // オブジェクトを使用済みにする
            usedObjects[randomIndex] = true;
        }
    }

    // 配列をシャッフルするメソッド
    void ShuffleArray(Transform[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(0, array.Length);
            Transform temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

}
