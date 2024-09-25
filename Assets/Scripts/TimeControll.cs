using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeControll : MonoBehaviour
{
    public float timer;
    public Text timerText;
    private GameObject objectPlacer;
    private ObjectCount objectCount;
    SceneControll sc;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        objectPlacer = GameObject.Find("ObjectPlacer");
        objectCount = objectPlacer.GetComponent<ObjectCount>();
        gameManager = this.gameObject;
        sc = gameManager.GetComponent<SceneControll>();
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
                sc.GameOver();
            }
            else
            {
                sc.ToGameFinish();
            }
        }
    }
}
