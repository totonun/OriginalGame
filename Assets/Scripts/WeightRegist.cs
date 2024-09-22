using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRegist : MonoBehaviour
{
    private Dictionary<GameObject, int> objectWeightDictionary;

    public List<Status> statusList;
    public List<GameObject> prefabList;

    public List<Status> listByLevel1;
    public List<Status> listByLevel2;
    public List<Status> listByLevel3;

    public List<GameObject> prefabByLevel1;
    public List<GameObject> prefabByLevel2;
    public List<GameObject> prefabByLevel3;

    public int weightClass;

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
            CreateStatus("�A���p�J", 60000, obj),
            CreateStatus("�A���C�O�}", 6000, obj),
            CreateStatus("�z�b�L���N�O�}(���X)", 200000, obj),
            CreateStatus("�G�r�t���C", 30, obj),
            CreateStatus("�S�}�t�A�U���V", 100000, obj),
            CreateStatus("�w���W�J", 450000, obj),
            CreateStatus("���јa��", 600000, obj),
            CreateStatus("���b�T�[�p���_", 45000, obj),
            CreateStatus("�������b�g", 10000, obj),
            CreateStatus("�������K", 120, obj),
            CreateStatus("���₵(1�{)", 2, obj),
            CreateStatus("�p���_", 120000, obj),
            CreateStatus("�v�e���m�h��", 15000, obj),
            CreateStatus("�^�P�m�R(������)", 10000, obj),
            CreateStatus("���܂ꂽ�Ă̎q��", 50000, obj),
        };
        //statusList.Sort((a, b) => string.Compare(a.objName, b.objName));
        statusList.Sort((a, b) => b.setWeight - a.setWeight);

        /*
        for(int i = 0; i < statusList.Count; i++)
        {
            Debug.Log(statusList[i].setWeight);
        }
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
    
    //List�ɓo�^
    private void Regist()
    {
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

    public void DevideByLevel()
    {
        for(int i = 0; i < statusList.Count; i++)
        {
            int weight = statusList[i].setWeight;
            if(weight < 3000)
            {
                listByLevel1.Add(statusList[i]);
                prefabByLevel1.Add(statusList[i].setObject);
                weightClass = 1;
            }
            else if (weight <= 50000)
            {
                listByLevel2.Add(statusList[i]);
                prefabByLevel2.Add(statusList[i].setObject);
                weightClass = 2;
            }
            else
            {
                listByLevel3.Add(statusList[i]);
                prefabByLevel3.Add(statusList[i].setObject);
                weightClass = 3;
            }
        }
        //Debug.Log("1: " + prefabByLevel1.Count);
        //Debug.Log("2: " + prefabByLevel2.Count);
        //Debug.Log("3: " + prefabByLevel3.Count);

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
