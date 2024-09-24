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

    private bool isDragging = false; // �h���b�O�����ǂ����̃t���O
    private bool isCollision = false;
    private bool hasTriggered = false; // �g���K�[�������������ǂ����̃t���O
    private bool objectCreated = false; // �I�u�W�F�N�g���������ꂽ���ǂ����̃t���O
    private bool hasScored = false; // �_������x�������Z���ꂽ�����L�^����t���O

    RectTransform rectTransform;
    Rigidbody2D rb;
    CapsuleCollider2D collider;

    public string message;

    public Collider2D targetCollider; // �d�Ȃ���`�F�b�N����Ώۂ̃R���C�_�[
    //public float overlapThreshold = -5.0f; // ���̋����ȏ�d�Ȃ�����Y�����Œ肷��

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
        // �}�E�X�{�^���������ꂽ���Ƀh���b�O�J�n
        isDragging = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnMouseUp()
    {
        // �}�E�X�{�^���������ꂽ���Ƀh���b�O�I��
        isDragging = false;

        // �R���[�`�����g���ď����҂��Ă���ʒu���`�F�b�N
        StartCoroutine(CheckCollisionAfterDelay());
    }


    //���[���h���W�ɕϊ����Ȃ����
    private void MouseFollow()
    {
            Vector3 mousePos = Input.mousePosition;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z); // Z���̈ʒu�͌Œ�
    }

    private void setOnCanvas()
    {
        GameObject newObj = (GameObject)Instantiate(prefabObject, originalPos, Quaternion.identity);
        objectCreated = true; // �I�u�W�F�N�g���������ꂽ���Ƃ��L�^

         newObj.name = prefabObject.name;
         newObj.GetComponent<ScrollMove>().weight = weightController.GetComponent<WeightRegist>().weightReturn(newObj);

        objectPlacer.GetComponent<ObjectCount>().PlacedObjectCount(newObj.name);

        RectTransform rectTransform = newObj.GetComponent<RectTransform>();
            newObj.transform.SetParent(canvas.transform, false);

            // ���[�J�����W�� originalPos ��ϊ����Đݒ�
            rectTransform.localPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(originalPos);

            newObj.GetComponent<CapsuleCollider2D>().isTrigger = false;
            newObj.SetActive(true);

        CapsuleCollider2D collider2D = newObj.gameObject.GetComponent<CapsuleCollider2D>();
        collider2D.isTrigger = false;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (hasTriggered) return; // �g���K�[�����łɔ������Ă���Ή������Ȃ�
        if (objectCreated) return; // ���ɃI�u�W�F�N�g����������Ă���Ή������Ȃ�
        if (hasScored) return;

        isCollision = true;
        hasTriggered = true; // �g���K�[����x��������������

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
        // 0.1�b�҂��Ă��珈�����s��
        yield return new WaitForSeconds(0.8f);

        // �����Փ˂��Ă��Ȃ���Ό��̈ʒu�ɖ߂�
        if (!isCollision)
        {
            this.rectTransform.position = originalPos;
        }
        else
        {
            
        }

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        // �t���O�����Z�b�g
        isCollision = false;
        hasTriggered = false; // �g���K�[�����Z�b�g
        objectCreated = false; // �I�u�W�F�N�g�����̃t���O�����Z�b�g
    }

}
