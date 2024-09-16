using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject[] objectsToPlace; // 配置するオブジェクトの配列
    public Transform[] positions; // 配置する位置の配列

    public GameObject canvas;

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // 配置場所のインデックスをランダムにシャッフル
        ShuffleArray(positions);

        // オブジェクトを配置する
        PlaceObjectsRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // オブジェクトをランダムに配置するメソッド
    void PlaceObjectsRandomly()
    {
        int count = Mathf.Min(objectsToPlace.Length, positions.Length); // 小さい方の要素数をcountに代入する
        Debug.Log("Count:" + count);

        bool[] usedObjects = new bool[objectsToPlace.Length]; // オブジェクトが使用されたかを追跡する配列

        for (int i = 0; i < count; i++)
        {
            // 使用されていないオブジェクトのインデックスをランダムに選ぶ
            int randomIndex = Random.Range(0, objectsToPlace.Length);

            // 使用済みのオブジェクトが選ばれている場合は新しいインデックスを選び直す
            while (usedObjects[randomIndex])
            {
                randomIndex = Random.Range(0, objectsToPlace.Length);
            }

            // 選ばれたオブジェクトをランダムな位置に配置する
            GameObject newObject = Instantiate(objectsToPlace[randomIndex]);

            // 新しいオブジェクトをCanvasの子に設定
            newObject.transform.SetParent(canvas.transform, false);

            // newObjectのRectTransformを取得して、positionの値を設定
            rectTransform = newObject.GetComponent<RectTransform>();

            // ここでpositions[i].positionをローカル座標系に変換して設定する
            rectTransform.anchoredPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(positions[i].position);

            // 新しく生成されたオブジェクトをアクティブにする（元のプレハブではなく新しいインスタンスに対して行う）
            newObject.SetActive(true);

            // オブジェクトを使用済みにマークする
            usedObjects[randomIndex] = true;

            // オブジェクトを使用済みにマークする
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
