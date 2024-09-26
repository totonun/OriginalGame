using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScaleMove : MonoBehaviour
{
    public GameObject rightScale;
    public GameObject leftScale;

    public float rightdirection;
    public float leftdirection;

    public bool changeDirectionTriggerR;
    public bool changeDirectionTriggerL;

    //public int direction;

    void Awake()
    {
        rightdirection = 1f;
        leftdirection = -1f;
        changeDirectionTriggerR = false;
        changeDirectionTriggerL = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((int)rightScale.GetComponent<RectTransform>().transform.position.y);
        rightScale.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0.1f * rightdirection);
        leftScale.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0.1f * leftdirection);

        //Debug.Log(rightScale.GetComponent<RectTransform>().anchoredPosition.y);
        if (changeDirectionTriggerR)
        {
            rightdirection *= -1f;
            Debug.Log("Right" + rightdirection);
            changeDirectionTriggerR = false;
        }
        else if (changeDirectionTriggerL)
        {
            leftdirection *= -1f;
            Debug.Log("Left" + leftdirection);
        changeDirectionTriggerL = false;
        }
    }
}
