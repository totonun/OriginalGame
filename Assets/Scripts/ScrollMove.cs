using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMove : MonoBehaviour
{
    bool moveTrigger;

    public GameObject rightScale;
    public GameObject leftScale;
    public GameObject weightController;
    public GameObject canvas;

    //public GameObject thisObject;
    public GameObject prefabObject;

    //public int distance = 30;
    public int weight;


    private Vector3 originalPos;
    public Vector3 prePos;
    public Vector3 addedPos;

    private bool isDragging = false; // ドラッグ中かどうかのフラグ
    private bool isCollision = false;
    private bool hasTriggered = false; // トリガーが発生したかどうかのフラグ
    private bool objectCreated = false; // オブジェクトが生成されたかどうかのフラグ

    RectTransform rectTransform;

    public string message;

    private string thisName;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = new Vector3(this.rectTransform.position.x, this.rectTransform.position.y, this.rectTransform.position.z);

        weightController = GameObject.Find("WeightController");
        rightScale = GameObject.Find("RightScale");
        leftScale = GameObject.Find("LeftScale");
        canvas = GameObject.Find("Canvas");

        //Debug.Log("thisName: " + thisName);
        prefabObject = (GameObject)Resources.Load(thisName);
        getWeight();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            MouseFollow();
        }
    }

    public void OnMouseDown()
    {
        // マウスボタンが押された時にドラッグ開始
        isDragging = true;
    }

    public void OnMouseUp()
    {
        // マウスボタンが離された時にドラッグ終了
        isDragging = false;

        // コルーチンを使って少し待ってから位置をチェック
        StartCoroutine(CheckCollisionAfterDelay());
    }


    //ワールド座標に変換しないやつ
    private void MouseFollow()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z); // Z軸の位置は固定
    }

    private void addedPosSet()
    {
        //前に設置したものの座標を保存
        prePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    private void setOnCanvas()
    {
        //Debug.Log("Instance: " + prefabObject.name);
        GameObject newObj = (GameObject)Instantiate(prefabObject, originalPos, Quaternion.identity);

        RectTransform rectTransform = newObj.GetComponent<RectTransform>();
        newObj.transform.SetParent(canvas.transform, false);

        // ローカル座標に originalPos を変換して設定
        rectTransform.localPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(originalPos);

        newObj.GetComponent<CapsuleCollider2D>().isTrigger = false;
        newObj.SetActive(true);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (hasTriggered) return; // トリガーがすでに発生していれば何もしない
        if (objectCreated) return; // 既にオブジェクトが生成されていれば何もしない

        isCollision = true;
        hasTriggered = true; // トリガーを一度だけ発生させる
        objectCreated = true; // オブジェクトが生成されたことを記録

        if (other.gameObject.tag == "Right")
        {
            //message = "RightAddWeight";
            this.gameObject.tag = "Right";
            weightController.GetComponent<WeightControll>().RightAddWeight(weight);
        }
        else if (other.gameObject.tag == "Left")
        {
            //message = "LeftAddWeight";
            this.gameObject.tag = "Left";
            weightController.GetComponent<WeightControll>().LeftAddWeight(weight);
        }

        //weightController.SendMessage(message, weight, SendMessageOptions.RequireReceiver);
        setOnCanvas();
    }

    private IEnumerator CheckCollisionAfterDelay()
    {
        // 0.1秒待ってから処理を行う
        yield return new WaitForSeconds(0.1f);

        // もし衝突していなければ元の位置に戻す
        if (!isCollision)
        {
            this.rectTransform.position = originalPos;
        }

        // フラグをリセット
        isCollision = false;
        hasTriggered = false; // トリガーをリセット
        objectCreated = false; // オブジェクト生成のフラグもリセット
    }

    private void getWeight()
    {
        GameObject obj = GameObject.Find("WeightController");
        List <Status> statsues = obj.GetComponent<WeightRegist>().statusList;
        //Debug.Log(obj);
        for (int i = 0; i < statsues.Count; i++)
        {
            //Debug.Log(statsues[i]);
            if (statsues[i].objName + "(Clone)" == this.gameObject.name)
            {
                weight = statsues[i].setWeight;
                thisName = statsues[i].objName;
                //Debug.Log(thisName);
            }
        }
    }

}
