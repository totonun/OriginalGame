using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRegist : MonoBehaviour
{
    //private Dictionary<GameObject, int> objectWeightDictionary;

    public List<Status> statusList;
    public List<GameObject> prefabList;

    //public List<Status> listByLevel1;
    //public List<Status> listByLevel2;
    //public List<Status> listByLevel3;

    public List<GameObject> prefabByLevel1;
    public List<GameObject> prefabByLevel2;
    public List<GameObject> prefabByLevel3;

    //public static int weightClass;

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
            //CreateStatus("�m�[�gPC", 1800, obj),
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
            CreateStatus("�A���R�[�������v", 150, obj),
            CreateStatus("������ꂽ�����S", 100, obj),        
            CreateStatus("�r�[���P�[�X", 18000, obj),          
            CreateStatus("�J�b�v�߂�", 70, obj),               // ��ʓI�ȃJ�b�v�˂̏d��
            CreateStatus("�d�H�h����", 5000, obj),             // ���^�d�H�h�����̏d��
            CreateStatus("�d���v", 500, obj),                  // ���^�̓d���v�̏d��
            CreateStatus("�h�[���J�o�[", 1000, obj),           // �h�[���J�����J�o�[�̏d��
            CreateStatus("�Q�[�~���OPC", 8000, obj),           // �Q�[�~���OPC�{�̂̏d��
            CreateStatus("�q�[�g�K��", 1200, obj),             // �q�[�g�K���̏d��
            CreateStatus("���߂��̊�", 800, obj),              // ���߂��p�̊��̏d��
            CreateStatus("���Ɋ�", 150, obj),                  // ��ʓI�Ȃ��Ɋʂ̏d��
            CreateStatus("����", 20000, obj),                  // ��ʓI�ȍ��̏d��
            CreateStatus("����݊���l�`", 300, obj),          // ���^�̂���݊���l�`�̏d��
            CreateStatus("���X�t���X�R", 200, obj),            // 500ml�̃��X�t���X�R�̏d��
            CreateStatus("���n������", 6000, obj),             // ���^�̐��n������
            CreateStatus("���H�O���X", 50, obj),               // �y�ʂ̓��H�O���X
            CreateStatus("�|�X�g", 20000, obj),                // ��ʓI�ȊX�̃|�X�g�̏d��
            CreateStatus("�O�p��~��", 1000, obj),             // �W���I�ȎO�p��~�̏d��
            CreateStatus("���ˋ@", 8000, obj),                 // �ƒ�p���ˋ@�̏d��
            CreateStatus("����΂�", 300, obj),                // ��ʓI�Ȃ���΂�̏d��
            CreateStatus("���g�u���b�N", 500000, obj),         // ���^�̏��g�u���b�N�̏d��
            CreateStatus("�^�u���b�g", 500, obj),              // ��ʓI�ȃ^�u���b�g�̏d��
            CreateStatus("�ؐ����炢", 3000, obj),             // �ؐ����炢�̏d��
            CreateStatus("���", 400, obj),                    // ����������̏d��
            CreateStatus("���ѓV��", 500, obj),                // ��ʓI�Ȃ��ѓV���̏d��
            CreateStatus("�g�[�X�g", 50, obj),                 // �ꖇ�̃g�[�X�g�̏d��
            CreateStatus("�Ղ̊�", 200, obj),                  // �`���I�ȌՂ̊��̏d��
            CreateStatus("�����p�b�N", 350, obj),              // ��ʓI�ȓ����̏d��
            CreateStatus("�肢�̐���", 3000, obj),             // ���^�̐����ʂ̏d��
            CreateStatus("���[�v��", 6000, obj),               // ���[�v���̕��ϓI�ȏd��
            CreateStatus("��������", 100, obj)                 // ����������������̏d��

        };
        statusList.Sort((a, b) => string.Compare(a.objName, b.objName));

        //�d���~���ɕ��ׂ�
        //statusList.Sort((a, b) => b.setWeight - a.setWeight);
        
        /*
        for(int i = 0; i < statusList.Count; i++)
        {
            Debug.Log(statusList[i].setWeight + statusList[i].objName);
        }
        //Debug.Log("    ");
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
        //prefabList.Sort((a, b) => b.GetComponent<ScrollMove>().weight - a.GetComponent<ScrollMove>().weight);
        prefabList.Sort((a, b) => string.Compare(a.name, b.name));
        //Debug.Log(prefabList.Count + " : " + statusList.Count);

        if (prefabList.Count == statusList.Count)
        {
            for (int j = 0; j < statusList.Count; j++)
            {
                statusList[j].setObject = prefabList[j];
                //Debug.Log(statusList[j].objName + " : " + prefabList[j].name);
            }
        }

    }

    public void DevideByLevel()
    {
        for(int i = 0; i < statusList.Count; i++)
        {
            int weight = statusList[i].setWeight;
            //Debug.Log(weight);
            if(weight < 400)
            {
                //listByLevel1.Add(statusList[i]);
                prefabByLevel1.Add(statusList[i].setObject);
               // weightClass = 1;
            }
            else if (weight < 9000)
            {
                //listByLevel2.Add(statusList[i]);
                prefabByLevel2.Add(statusList[i].setObject);
                //weightClass = 2;
            }
            else
            {
                //listByLevel3.Add(statusList[i]);
                prefabByLevel3.Add(statusList[i].setObject);
                //weightClass = 3;
            }
        }
        /*
        for(int j = 0; j < prefabByLevel1.Count; j++)
        {
            Debug.Log(prefabByLevel1[j].name);
        }
        */
        /*
        Debug.Log("1: " + prefabByLevel1.Count);
        Debug.Log("2: " + prefabByLevel2.Count);
        Debug.Log("3: " + prefabByLevel3.Count);
        */

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
