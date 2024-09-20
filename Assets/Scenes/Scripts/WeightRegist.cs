using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRegist : MonoBehaviour
{
    //public List<GameObject> gameObjects = new List<GameObject>(); // �Ǘ�����GameObject�̃��X�g
    //public List<int> weights = new List<int>();            // ����ɑΉ�����d���̃��X�g

    private Dictionary<GameObject, int> objectWeightDictionary;

    public List<Status> statusList;
    public List<GameObject> prefabList;

    public int[] weightArray;
    private GameObject obj = null;

    public GameObject[] prefabArray;

    // Start is called before the first frame update
    private void Awake()
    {
        statusList = new List<Status>
        {
            CreateStatus("���", 180, obj),
            CreateStatus("�o�i�i", 120, obj),
            CreateStatus("�˂�", 4000, obj),
            CreateStatus("����", 60000, obj),
            CreateStatus("����", 500000, obj),
            CreateStatus("����(�r��)", 1000, obj),
            CreateStatus("�m�[�gPC", 1800, obj),
        };
        statusList.Sort((a, b) => string.Compare(a.objName, b.objName));

        prefabArray = Resources.LoadAll<GameObject>("Prefabs");
        Regist();
    }

    void Start()
    {
        //ObjectAddList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //List�ɓo�^
    void Regist()
    {

        //List�ɓo�^
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

    //���X�g����Q�Ƃ��ē������O�̂��̂̏d����Ԃ�
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