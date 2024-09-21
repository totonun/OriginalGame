using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeforeStartTimer : MonoBehaviour
{
    private float timer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Ç†Ç∆Å@" + timer.ToString("f0") + " ïb";
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            SceneManager.LoadScene("Main");
        }
    }
}
