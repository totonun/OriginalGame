using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeTimer : MonoBehaviour
{
    public float timer;

    public GameObject asobikatas;
    public GameObject rules;
    public GameObject startButton;
    public GameObject nextButton;

    public bool isTimerFinish;

    private bool isNextScene;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
        asobikatas.SetActive(true);
        rules.SetActive(false);
        startButton.SetActive(false);
        isTimerFinish = false;
        nextButton.SetActive(true);
        isNextScene = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimerFinish)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                if (isNextScene)
                {
                    startButton.SetActive(true);
                    isNextScene = false;
                }
                isTimerFinish = true;
                timer = 0f;
            }
        }

        /*
        if (!isTimerFinish)
        {
            timer -= Time.deltaTime;
            if (timer <= 2f)
            {
                asobikatas.SetActive(true);
                if (timer <= 1f)
                {
                    rules.SetActive(true);
                    if (timer <= 0.0f)
                    {
                        startButton.SetActive(true);
                        timer = 0f;
                        isTimerFinish = true;
                    }
                }
            }
        }
        */
    }

    public void changeScreen()
    {
        asobikatas.SetActive(false);
        rules.SetActive(true);
        nextButton.SetActive(false);
        isTimerFinish = false;
        timer = 2f;
        isNextScene = true;
    }
}
