using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeforeStartTimer : MonoBehaviour
{
    private float timer;
    public Text timerText;
    public bool timerStart;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.5f;
        StartCoroutine(WaitAndExecute());
        timerStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            timer -= Time.deltaTime;
            timerText.text = "あと　" + timer.ToString("f0") + " 秒";
            if (timer <= 0.6f)
            {
                timerText.text = "はじまるよ！";
                if(timer <= 0.0f)
                {
                    timer = 0.0f;
                    SceneManager.LoadScene("Main");
                }
            }
        }
    }

    // コルーチン関数
    IEnumerator WaitAndExecute()
    {
        // 1秒待つ
        yield return new WaitForSeconds(0.5f);

        timerStart = true;
    }

}
