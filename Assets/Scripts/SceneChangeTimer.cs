using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeTimer : MonoBehaviour
{
    public float timer;

    public GameObject asobikatas;
    public GameObject rules;
    public GameObject descliptionText;

    public bool isTimerFinish;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        asobikatas.SetActive(false);
        rules.SetActive(false);
        descliptionText.SetActive(false);
        isTimerFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimerFinish)
        {
            timer -= Time.deltaTime;
            if (timer <= 2.5f)
            {
                asobikatas.SetActive(true);
                if (timer <= 1.5f)
                {
                    rules.SetActive(true);
                    if (timer <= 0.0f)
                    {
                        descliptionText.SetActive(true);
                        timer = 0f;
                        isTimerFinish = true;
                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                this.gameObject.GetComponent<SceneControll>().ToPrepareStart();
            }
        }
    }
}
