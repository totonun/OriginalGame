using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacer : MonoBehaviour
{
    public List<GameObject> objectsToPlace; // �z�u����I�u�W�F�N�g�̃��X�g
    public GameObject[] objectToPlaceArray;
    public static int[] placedObjects; //�z�u���ꂽ�I�u�W�F�N�g�̏d��
    public Transform[] positions; // �z�u����ʒu�̔z��
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

        count = Mathf.Min(objectsToPlace.Count, positions.Length); // ���������̗v�f����count�ɑ������
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
        // �z�u�ꏊ�̃C���f�b�N�X�������_���ɃV���b�t��
        ShuffleArray(positions);

        //  Prefab�����݂���I�u�W�F�N�g�̐����v�f���̔z��
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

    // �I�u�W�F�N�g�������_���ɔz�u���郁�\�b�h
    void PlaceObjectsRandomly()
    {

        bool[] usedObjects = new bool[objectsToPlace.Count]; // �I�u�W�F�N�g���g�p���ꂽ����ǐՂ���z��

        for (int i = 0; i < count; i++)
        {
            // �g�p����Ă��Ȃ��I�u�W�F�N�g�������_���ɑI��
            int randomIndex = Random.Range(0, objectsToPlace.Count);

            // �������[�v����̂��߂̃J�E���^�[
            int attempts = 0;
            int maxAttempts = objectsToPlace.Count * 2; // �ő厎�s�񐔂�ݒ�

            // �g�p�ς݂̃I�u�W�F�N�g���I�΂�Ă���ꍇ�͑I�ђ���
            while (usedObjects[randomIndex] && attempts < maxAttempts)
            {
                randomIndex = Random.Range(0, objectsToPlace.Count);
                attempts++;
            }

            // ���ׂẴI�u�W�F�N�g���g�p�ς݂Ȃ烋�[�v�𔲂���
            if (attempts >= maxAttempts) break;

            // �I�΂ꂽ�I�u�W�F�N�g�������_���Ȉʒu�ɔz�u����
            GameObject newObject = Instantiate(objectsToPlace[randomIndex]);
            newObject.name = objectsToPlace[randomIndex].name;
            objectNames[i] = newObject.name;

            newObject.GetComponent<ScrollMove>().weight = weightController.GetComponent<WeightRegist>().weightReturn(newObject);
            placedObjects[i] = newObject.GetComponent<ScrollMove>().weight;

           texts[i].text = newObject.name;
            texts[i].rectTransform.position = new Vector3(positions[i].position.x, positions[i].transform.position.y + 60, 0);

            // �I�u�W�F�N�g���g�p�ς݂Ƀ}�[�N����
            usedObjects[randomIndex] = true;

        // �V�����I�u�W�F�N�g��Canvas�̎q�ɐݒ�
        newObject.transform.SetParent(canvas.transform, false);

            // newObject��RectTransform���擾���āAposition�̒l��ݒ�
            rectTransform = newObject.GetComponent<RectTransform>();

            // ���[�J�����W�n�ɕϊ����Đݒ肷��
            rectTransform.anchoredPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(positions[i].position);

            // �V�����������ꂽ�I�u�W�F�N�g���A�N�e�B�u�ɂ���
            newObject.SetActive(true);

            // �I�u�W�F�N�g���g�p�ς݂ɂ���
            usedObjects[randomIndex] = true;
        }
    }

    // �z����V���b�t�����郁�\�b�h
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
