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

    private bool isDragging = false; // �h���b�O�����ǂ����̃t���O
    private bool isCollision = false;
    private bool hasTriggered = false; // �g���K�[�������������ǂ����̃t���O
    private bool objectCreated = false; // �I�u�W�F�N�g���������ꂽ���ǂ����̃t���O

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
        // �}�E�X�{�^���������ꂽ���Ƀh���b�O�J�n
        isDragging = true;
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

    private void addedPosSet()
    {
        //�O�ɐݒu�������̂̍��W��ۑ�
        prePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    private void setOnCanvas()
    {
        //Debug.Log("Instance: " + prefabObject.name);
        GameObject newObj = (GameObject)Instantiate(prefabObject, originalPos, Quaternion.identity);

        RectTransform rectTransform = newObj.GetComponent<RectTransform>();
        newObj.transform.SetParent(canvas.transform, false);

        // ���[�J�����W�� originalPos ��ϊ����Đݒ�
        rectTransform.localPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(originalPos);

        newObj.GetComponent<CapsuleCollider2D>().isTrigger = false;
        newObj.SetActive(true);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (hasTriggered) return; // �g���K�[�����łɔ������Ă���Ή������Ȃ�
        if (objectCreated) return; // ���ɃI�u�W�F�N�g����������Ă���Ή������Ȃ�

        isCollision = true;
        hasTriggered = true; // �g���K�[����x��������������
        objectCreated = true; // �I�u�W�F�N�g���������ꂽ���Ƃ��L�^

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
        // 0.1�b�҂��Ă��珈�����s��
        yield return new WaitForSeconds(0.1f);

        // �����Փ˂��Ă��Ȃ���Ό��̈ʒu�ɖ߂�
        if (!isCollision)
        {
            this.rectTransform.position = originalPos;
        }

        // �t���O�����Z�b�g
        isCollision = false;
        hasTriggered = false; // �g���K�[�����Z�b�g
        objectCreated = false; // �I�u�W�F�N�g�����̃t���O�����Z�b�g
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
