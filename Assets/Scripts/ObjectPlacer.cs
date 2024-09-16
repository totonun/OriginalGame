using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject[] objectsToPlace; // �z�u����I�u�W�F�N�g�̔z��
    public Transform[] positions; // �z�u����ʒu�̔z��

    public GameObject canvas;

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // �z�u�ꏊ�̃C���f�b�N�X�������_���ɃV���b�t��
        ShuffleArray(positions);

        // �I�u�W�F�N�g��z�u����
        PlaceObjectsRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �I�u�W�F�N�g�������_���ɔz�u���郁�\�b�h
    void PlaceObjectsRandomly()
    {
        int count = Mathf.Min(objectsToPlace.Length, positions.Length); // ���������̗v�f����count�ɑ������
        Debug.Log("Count:" + count);

        bool[] usedObjects = new bool[objectsToPlace.Length]; // �I�u�W�F�N�g���g�p���ꂽ����ǐՂ���z��

        for (int i = 0; i < count; i++)
        {
            // �g�p����Ă��Ȃ��I�u�W�F�N�g�̃C���f�b�N�X�������_���ɑI��
            int randomIndex = Random.Range(0, objectsToPlace.Length);

            // �g�p�ς݂̃I�u�W�F�N�g���I�΂�Ă���ꍇ�͐V�����C���f�b�N�X��I�ђ���
            while (usedObjects[randomIndex])
            {
                randomIndex = Random.Range(0, objectsToPlace.Length);
            }

            // �I�΂ꂽ�I�u�W�F�N�g�������_���Ȉʒu�ɔz�u����
            GameObject newObject = Instantiate(objectsToPlace[randomIndex]);

            // �V�����I�u�W�F�N�g��Canvas�̎q�ɐݒ�
            newObject.transform.SetParent(canvas.transform, false);

            // newObject��RectTransform���擾���āAposition�̒l��ݒ�
            rectTransform = newObject.GetComponent<RectTransform>();

            // ������positions[i].position�����[�J�����W�n�ɕϊ����Đݒ肷��
            rectTransform.anchoredPosition = canvas.GetComponent<RectTransform>().InverseTransformPoint(positions[i].position);

            // �V�����������ꂽ�I�u�W�F�N�g���A�N�e�B�u�ɂ���i���̃v���n�u�ł͂Ȃ��V�����C���X�^���X�ɑ΂��čs���j
            newObject.SetActive(true);

            // �I�u�W�F�N�g���g�p�ς݂Ƀ}�[�N����
            usedObjects[randomIndex] = true;

            // �I�u�W�F�N�g���g�p�ς݂Ƀ}�[�N����
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
