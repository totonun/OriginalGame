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
    private GameObject objectPlacer;
    private ObjectCount objectCount;

    // Start is called before the first frame update
    void Start()
    {
        objectPlacer = GameObject.Find("ObjectPlacer");
        objectCount = objectPlacer.GetComponent<ObjectCount>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "‚ ‚Æ" + timer.ToString("f0") + "•b";
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            if (!objectCount.checkUseObject() || !objectCount.differenceTrigger())
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                SceneManager.LoadScene("GameFinish");
            }
        }
    }
}
