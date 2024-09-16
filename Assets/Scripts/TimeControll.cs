using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class TimeControll : MonoBehaviour
{
    public float timer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "‚ ‚Æ" + timer.ToString("f0") + "•b";
        //Debug.Log(timerText.text);
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            SceneManager.LoadScene("GameFinish");
        }
    }
}
