using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControll : MonoBehaviour
{
    public GameObject itemController;
    public GameObject gameManager;
    public GameObject helpItem;
    //public GameObject rightParticle;
    //public GameObject leftParticle;
    public GameObject rightArrow;
    public GameObject leftArrow;

    public GameObject rightScaleText;
    public GameObject leftScaleText;

    public Text helpItemText;

    TimeControll tc;
    AudioSource audioSource;

    private bool itemMove;
    private bool timerTrigger;

    private float timer;

    public bool itemUsed;

    // Start is called before the first frame update
    void Start()
    {
        itemController = this.gameObject;
        tc = gameManager.GetComponent<TimeControll>();
        itemMove = false;
        timer = 3.0f;
        itemUsed = false;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        if (!ReleaseItem.isItem)
        {
            helpItem.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ReleaseItem.isItem) return;

        if (itemMove)
        {
            helpItemText.transform.position += new Vector3(0, 70, 0) * Time.deltaTime;
            //Debug.Log(helpItemText.transform.position.y);
            if(helpItemText.transform.position.y > 240)
            {
                helpItem.SetActive(false);
                if(helpItemText.transform.position.y > 260)
                {
                    itemMove = false;
                }
            }
        }
        else if (timerTrigger)
        {
            timer -= Time.deltaTime;
            if((int)timer == 0)
            {
                timerTrigger = false;
            }
        }
        else
        {
            //rightScaleText.GetComponent<Text>().enabled = false;
            //leftScaleText.GetComponent<Text>().enabled = false;
            rightScaleText.SetActive(false);
            leftScaleText.SetActive(false);

            //rightParticle.SetActive(false);
            //leftParticle.SetActive(false);
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
        }
    }

    public void itemHelp()
    {
        itemUsed = true;
        int rand = Random.Range(1, 6);
        string effectName = null;
        audioSource.Play();
        switch (rand)
        {
            case 1:
                effectName = "3秒延長するよ";
                tc.timer += 3;
                break;
            case 2:
                effectName = "右の重さ教えるよ";
                timerTrigger = true;
                //rightScaleText.GetComponent<Text>().enabled = true;
                //rightScaleText.enabled = true;
                rightScaleText.SetActive(true);
                break;
            case 3:
                effectName = "左の重さ教えるよ";
                timerTrigger = true;
                //leftScaleText.GetComponent<Text>().enabled = true;
                //leftScaleText.enabled = true;
                leftScaleText.SetActive(true);
                break;
            case 4:
                effectName = "重い方を教えるよ";
                if (WeightControll.rightSideWeight == WeightControll.leftSideWeight)
                {
                    rightArrow.SetActive(true);
                    leftArrow.SetActive(true);
                    timerTrigger = true;
                }
                else if (WeightControll.rightSideWeight > WeightControll.leftSideWeight)
                {
                    rightArrow.SetActive(true);
                    timerTrigger = true;
                }
                else
                {
                    leftArrow.SetActive(true);
                    timerTrigger = true;
                }

                /*
                if (WeightControll.rightSideWeight  ==  WeightControll.leftSideWeight)
                {
                    rightParticle.SetActive(true);
                    leftParticle.SetActive(true);
                    timerTrigger = true;
                }
                else if (WeightControll.rightSideWeight > WeightControll.leftSideWeight)
                {
                    rightParticle.SetActive(true);
                    timerTrigger = true;
                }
                else
                {
                    leftParticle.SetActive(true);
                    timerTrigger = true;
                }
                */

                break;
            case 5:
                effectName = "なにもしないよ";
                break;

        }
        helpItemText.text = effectName;
        itemMove = true;
    }
}
