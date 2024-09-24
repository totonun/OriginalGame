using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMove : MonoBehaviour
{
    public GameObject rightScale;
    public GameObject leftScale;
    public GameObject weightController;
    public GameObject canvas;
    public GameObject objectPlacer;

    public GameObject prefabObject;

    public int weight;

    private Vector3 originalPos;
    public Vector3 prePos;
    public Vector3 addedPos;

    private bool isDragging = false; // ドラッグ中かどうかのフラグ
    private bool isCollision = false;
    private bool hasTriggered = false; // トリガーが発生したかどうかのフラグ
    private bool objectCreated = false; // オブジェクトが生成されたかどうかのフラグ
    private bool hasScored = false; // 点数が一度だけ加算されたかを記録するフラグ

    RectTransform rectTransform;
    Rigidbody2D rb;
    CapsuleCollider2D collider;

    public string message;

    public Collider2D targetCollider; // 重なりをチェックする対象のコライダー
    //public float overlapThreshold = -5.0f; // この距離以上重なったらY軸を固定する

    public bool setCanvas;
    public bool freezeTrigger;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();

        collider = this.gameObject.GetComponent<CapsuleCollider2D>();
        collider.isTrigger = false;

        originalPos = new Vector3(this.rectTransform.position.x, this.rectTransform.position.y, this.rectTransform.position.z);

        weightController = GameObject.Find("WeightController");
        rightScale = GameObject.Find("RightScale");
        leftScale = GameObject.Find("LeftScale");
        canvas = GameObject.Find("Canvas");
        objectPlacer = GameObject.Find("ObjectPlacer");

        prefabObject = (GameObject)Resources.Load("Prefabs/" + this.gameObject.name);

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        freezeTrigger = false;
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
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    private void setOnCanvas()
    {
        GameObject newObj = (GameObject)Instantiate(prefabObject, originalPos, Quaternion.identity);
        objectCreated = true; // オブジェクトが生成されたことを記録

         newObj.name = prefabObject.name;
         newObj.GetComponent<ScrollMove>().weight = weightController.GetComponent<WeightRegist>().weightReturn(newObj);

        objectPlacer.GetComponent<ObjectCount>().PlacedObjectCount(newObj.name);

        RectTransform rectTransform = newObj.GetComponent<RectTransform>();
            newObj.transform.SetParent(canvas.transform, false);

            // ローカル座標に originalPos を変換して設定
            rectTransform.localPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(originalPos);

            newObj.GetComponent<CapsuleCollider2D>().isTrigger = false;
            newObj.SetActive(true);

        CapsuleCollider2D collider2D = newObj.gameObject.GetComponent<CapsuleCollider2D>();
        collider2D.isTrigger = false;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (hasTriggered) return; // トリガーがすでに発生していれば何もしない
        if (objectCreated) return; // 既にオブジェクトが生成されていれば何もしない
        if (hasScored) return;

        isCollision = true;
        hasTriggered = true; // トリガーを一度だけ発生させる

        int pWeight = this.gameObject.GetComponent<ScrollMove>().weight;

        if (other.gameObject.tag == "Right")
        {
            this.gameObject.tag = "Right";
            Debug.Log("Right");
            weightController.GetComponent<WeightControll>().RightAddWeight (pWeight);
            setOnCanvas();
        }
        else if (other.gameObject.tag == "Left")
        {
            this.gameObject.tag = "Left";
            Debug.Log("Left");
            weightController.GetComponent<WeightControll>().LeftAddWeight(pWeight);
            setOnCanvas();
        }

        hasScored = true;
    }

    private IEnumerator CheckCollisionAfterDelay()
    {
        // 0.1秒待ってから処理を行う
        yield return new WaitForSeconds(0.8f);

        // もし衝突していなければ元の位置に戻す
        if (!isCollision)
        {
            this.rectTransform.position = originalPos;
        }
        else
        {
            
        }

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        // フラグをリセット
        isCollision = false;
        hasTriggered = false; // トリガーをリセット
        objectCreated = false; // オブジェクト生成のフラグもリセット
    }

}
