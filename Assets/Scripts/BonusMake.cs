using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusMake : MonoBehaviour
{
    private string[] objectNames;
    private string bonusMessage;

    public Text bonusText;

    public List<string> bonusMessage1;
    public List<string> bonusMessage2;
    public List<string> bonusMessage3;

    // Start is called before the first frame update
    void Start()
    {
        bonusMessage1 = new List<string>
        {
            "������ꂽ�����S�A" +
            "�܂��J�b�v�߂�ɂ͏��ĂȂ��d���B",
            "�o�i�i�́A�����p�b�N�����������肵���d���B",
            "�G�r�t���C�́A���₵1�{���͂邩�ɏd�����B",
            "�������K�̓��X�t���X�R�����y�₩�B",
            "���ɊʁA���������肸�����肵�����݊��B",
            "����΂�́A���H�O���X�����m���ɏd���B",
            "�g�[�X�g�A�Ղ̊��ɂ͓��ꂩ�Ȃ�Ȃ��y���B",
            "�A���R�[�������v�́A���X�t���X�R��肿����Əd���B",
            "������ꂽ�����S���A" +
            "�J�b�v�߂�̂ق�����������ƕ��ɗ��܂�B",
            "����΂�͌v�Z�ł��邯�ǁA" +
            "��������̕����y���Ĉ����₷����B",
            "�o�i�i�̉h�{�����������ǁA" +
            "�g�[�X�g�̌y���ɂ͓G��Ȃ��ˁB",
            "�������K�̂ӂ�ӂ�Ȍy���ɔ�ׂ���A" +
            "���X�t���X�R�̐��������d��������B",
            "���₵(1�{)�̌y���͂�񂲂ɔ�ׂāA" +
            "�܂�ŉH�̂悤���ˁB",
            "�����p�b�N�̒��g�͂Ղ�Ղ邾���ǁA" +
            "�Ղ̊��̏d�݂͒m���̋l�܂�����B",
            "���Ɋʂ͒��g���������肾���ǁA" +
            "�G�r�t���C�̃T�N�T�N���͌y���������B",
        };

        bonusMessage2 = new List<string>
        {
            "�Q�[�~���OPC�������^�ԁH�A���C�O�}�ɔC����ƁA" +
            "������Ƃ����g���[�j���O���ˁB",
            "�^�u���b�g�̏d���Ɣ�ׂ�ƁA" +
            "���ѓV���̓w���V�[�Ɍ����邩���H",
            "�˂��͌y�����ǁA�h�[���J�o�[�̒��ɉB�ꂽ��" +
            "�o�Ă��Ȃ��d������B",
            "���߂��̊��̔M���������ǁA" +
            "�q�[�g�K���̔M�ɂ͕����邩�ȁH",
            "�肢�̐����������������Ă���邯�ǁA" +
            "���ˋ@�̏d���Ō�����������ˁB",
            "�d���v�������ł��A" +
            "�d�H�h�����̏d���ɂ͏��ĂȂ���B",
            "�ؐ����炢�̏d������������A" +
            "�A���C�O�}�ł����肽���邩���ˁB",
            "�A���C�O�}�ƃQ�[�~���OPC�A�ǂ������d�������āH" +
            "�A���C�O�}�͌y���t�b�g���[�N����I",
            "���ѓV���̕����y�����ǁA" +
            "�^�u���b�g�̕�������������" +
            "�c�������̘b�ˁB",
            "�h�[���J�o�[�͑傫�����ǁA" +
            "�˂��̂ق����C�y�Ɏ����グ����B",
            "�q�[�g�K���Ɗ��߂��̊��A" +
            "�ǂ������d���͂��邯�ǁA�g�������S�R�Ⴄ��ˁB",
            "����(�r��)�ƎO�p��~�A�ǂ������d�v�����ǁA" +
            "�d���͋����������I",
            "���̏d�����C�ɂȂ邯�ǁA" +
            "���n�����؂�����������d�������B",
            "���ˋ@�̏d���ɔ�ׂ���A�肢�̐�����" +
            "�����Ԃ�y�₩�ɖ�����������ˁB",
            "�d�H�h�����̕����d�����ǁA" +
            "�d���v�̐��l�̏d�݂�����Ȃ��B",
            "�ؐ����炢���d�����āH" +
            "�A���C�O�}�͂��̒��ł��났�����񂶂�Ȃ��H"
        };

        bonusMessage3 = new List<string>
        {
            "�A���p�J�͂��ӂ��ӂ����ǁA" +
            "�r�[���P�[�X�̏d���ɂ͓G��Ȃ��ˁB",
            "�^�P�m�R(������)�Ɣ�ׂ�ƁA" +
            "���܂̏d���͂܂��Ɍ��Ⴂ�I",
            "�S�}�t�A�U���V�������Ōy�₩�ł��A" +
            "���g�u���b�N�قǂ̏d���͂Ȃ��ˁB",
            "���܂ꂽ�Ă̎q���Ƃ������ׂ�ƁA" +
            "�d���͐e����̍�������ˁB",
            "�^�P�m�R(������)�ƍ��A" +
            "���Ƃɖ𗧂͍̂������ǁA" +
            "�y���̂̓^�P�m�R�B",
            "�|�X�g�͂�������d�����ǁA" +
            "�p���_���������炻��ȏゾ��B",
            "�������b�g�͏������Čy�����ǁA" +
            "�r�[���P�[�X�����ɂ͗͂��v���B",
            "�v�e���m�h���͋���Ԃ��ǁA" +
            "�d���͍��јa���ɗ��Ȃ������ˁB",
            "���b�T�[�p���_�ƃw���W�J�A" +
            "�ǂ������d�����Ȃ�Ĉ�ڗđR�I",
            "���g�u���b�N���d�����ǁA" +
            "�|�X�g���^�Ԃ̂��Ȃ��Ȃ��̘J�����ˁB",
            "�������傫�����ǁA" +
            "�z�b�L���N�O�}�̏d���ɂ͂��Ȃ�Ȃ��B",
            "�������b�g�̌y���́A" +
            "�v�e���m�h���̗��̏d�݂Ƃ͐����΂��ˁB",
            "���b�T�[�p���_�̂��킢���Əd���A" +
            "�^�P�m�R(������)�ɂ͓��ꏟ�ĂȂ��B",
            "���̏d������������A" +
            "�p���_�̑̏d�����{�����邱�Ƃ��v���o���āB",
            "���јa���ƃr�[���P�[�X�A���̕����d�����ǁA" +
            "�ǂ������ɓ����Ɗ�������ˁB",
            "���g�u���b�N�������グ��̂͑�ς����ǁA" +
            "���܂ɏ����������Ƒ�ς����H",
            "���܂ꂽ�Ă̎q���͌y�����ǁA" +
            "�z�b�L���N�O�}�ɂ͂܂��܂��͂��Ȃ��B",
            "�A���p�J�̏d���͌����ڒʂ�A" +
            "�S�}�t�A�U���V�̂����Ƃ肵���̏d�ɋ߂������H",
            "�|�X�g���d�����ǁA" +
            "�w���W�J�ɔ�ׂ���܂��y�������ˁB",
            "�p���_�̏d���ƍ��јa���A" +
            "�ǂ�����{�����[�����_����ˁB"
        };

        objectNames = ObjectPlacer.objectNames;
        searchWord(ObjectPlacer.listSelect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void searchWord(int num)
    {
        int rand = Random.Range(0, objectNames.Length); //�o�Ă�I�u�W�F�N�g�̒����烉���_���őI�o
        Debug.Log("Num :" + num);
        List<string> pMessage;
        pMessage = new List<string>();

        switch (num)
        {
            case 1:
                pMessage = new List<string>(bonusMessage1);
                break;
            case 2:
                pMessage = new List<string>(bonusMessage2);
                break;
            case 3:
                pMessage = new List<string>(bonusMessage3);
                break;
            default:
                //Debug.LogWarning("Unexpected value for num: " + num);  // �G���[���b�Z�[�W��\��
                break;
        }

        List<string> matchTexts = new List<string>();

        for (int i = 0; i < pMessage.Count; i++)
        {
            //Debug.Log(pMessage[i]);
            //Debug.Log(objectNames[rand]);

            //int strLength = pMessage[i].Length;


            if (pMessage[i].Contains(objectNames[rand]))
            {
                bonusMessage =  pMessage[i];
                //Debug.Log(bonusMessage);
                matchTexts.Add(bonusMessage);
            }
        }

        int selectText = Random.Range(0, matchTexts.Count);
        //Debug.Log(selectText);
        bonusText.text = matchTexts[selectText];
        if(matchTexts.Count == 0)
        {
            bonusText.text = "�d���𓖂Ă�̂��ĈĊO������";
        }

    }
}
