using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{

    public GameObject weightController;
    public Text rankText;
    public Text differText;

    public Text rightText;
    public Text leftText;
    private float rightWeight;
    private float leftWeight;

    AudioSource audioSource;
    public AudioClip[] audioClips;
    //private float difference;

    private string unit;


    // Start is called before the first frame update
    void Start()
    {
        weightController = GameObject.Find("WeightController");
        audioSource = this.gameObject.GetComponent<AudioSource>();
        inputTexts();
        if(CompareWeight.persentage == 100)
        {
            Play(0);
        }
        else if(CompareWeight.persentage <= 10)
        {
            Play(2);
        }
        else
        {
            Play(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void inputTexts()
    {
        rightWeight = (float)WeightControll.rightSideWeight;
        leftWeight = (float)WeightControll.leftSideWeight;

        if (rightWeight >= 1000 && leftWeight >= 1000)
        {
            unit = " kg";
            rightWeight = (float)rightWeight / 1000;
            leftWeight = (float)leftWeight / 1000;
        }
        else
        {
            unit = " g";
        }

        rightText.text = "‰E: " + rightWeight.ToString() + unit;
        leftText.text = "¶: " + leftWeight.ToString() + unit;

        rankText.text = "‚Ò‚Á‚½‚ñ‚±“xF " + CompareWeight.persentage.ToString() + " %";

        if (CompareWeight.persentage > InputMaxScore.maxPersentage)
        {
            InputMaxScore.maxPersentage = CompareWeight.persentage;
        }
    }

    private void Play(int i)
    {
        switch (i)
        {
            case 0:
                audioSource.PlayOneShot(audioClips[0]);
                break;
            case 1:
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case 2:
                audioSource.PlayOneShot(audioClips[2]);
                break;
        }
    }
}
