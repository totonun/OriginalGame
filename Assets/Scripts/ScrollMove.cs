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

    private bool isDragging = false;
    private bool isCollision = false;
    private bool hasTriggered = false; 
    private bool objectCreated = false; 
    private bool hasScored = false;

    RectTransform rectTransform;
    Rigidbody2D rb;
    CapsuleCollider2D collider2d;

    public string message;

    public Collider2D targetCollider; 

    public bool setCanvas;
    public bool freezeTrigger;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();

        collider2d = this.gameObject.GetComponent<CapsuleCollider2D>();
        collider2d.isTrigger = false;
        collider2d.enabled = false;

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
        if (objectCreated) return;

        if (isDragging)
        {
            MouseFollow();
        }
        
    }

    public void OnMouseDown()
    {
        collider2d.enabled = true;
        isDragging = true;
        rb.constraints = RigidbodyConstraints2D.None;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        StartCoroutine(CheckCollisionAfterDelay());
    }

    private void MouseFollow()
    {
            Vector3 mousePos = Input.mousePosition;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z); 
    }

    private void setOnCanvas()
    {
        GameObject newObj = (GameObject)Instantiate(prefabObject, originalPos, Quaternion.identity);
        objectCreated = true;

         newObj.name = prefabObject.name;
         newObj.GetComponent<ScrollMove>().weight = weightController.GetComponent<WeightRegist>().weightReturn(newObj);

        objectPlacer.GetComponent<ObjectCount>().PlacedObjectCount(newObj.name);

        RectTransform rectTransform = newObj.GetComponent<RectTransform>();
            newObj.transform.SetParent(canvas.transform, false);

            rectTransform.localPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(originalPos);

            newObj.GetComponent<CapsuleCollider2D>().isTrigger = false;
            newObj.SetActive(true);

        CapsuleCollider2D collider2D = newObj.gameObject.GetComponent<CapsuleCollider2D>();
        collider2D.isTrigger = false;
        GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (hasTriggered) return; 
        if (objectCreated) return;
        if (hasScored) return;

        isCollision = true;
        hasTriggered = true;

        int pWeight = this.gameObject.GetComponent<ScrollMove>().weight;

        if (other.gameObject.tag == "Right")
        {
            this.gameObject.tag = "Right";
            weightController.GetComponent<WeightControll>().RightAddWeight (pWeight);
            setOnCanvas();
        }
        else if (other.gameObject.tag == "Left")
        {
            this.gameObject.tag = "Left";
            weightController.GetComponent<WeightControll>().LeftAddWeight(pWeight);
            setOnCanvas();
        }

        hasScored = true;
    }

    private IEnumerator CheckCollisionAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);

        if (!isCollision)
        {
            this.rectTransform.position = originalPos;
        }

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        isCollision = false;
        hasTriggered = false; 
        objectCreated = false; 
    }

}
