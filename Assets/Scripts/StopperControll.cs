using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperControll: MonoBehaviour
{
    public GameObject gameManager;

    public float rightdirection;
    public float leftdirection;

    public bool changeDirectionTriggerR;
    public bool changeDirectionTriggerL;

    // Start is called before the first frame update
    void Start()
    {
        rightdirection = gameManager.GetComponent<TitleScaleMove>().rightdirection;
        leftdirection = gameManager.GetComponent<TitleScaleMove>().leftdirection;
        changeDirectionTriggerR = gameManager.GetComponent<TitleScaleMove>().changeDirectionTriggerR;
        changeDirectionTriggerL = gameManager.GetComponent<TitleScaleMove>().changeDirectionTriggerL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision");

        if (collision.tag == "Right")
        {
            gameManager.GetComponent<TitleScaleMove>().changeDirectionTriggerR = true;
            Debug.Log("Right" + rightdirection);
        }
        else if (collision.tag == "Left")
        {
            gameManager.GetComponent<TitleScaleMove>().changeDirectionTriggerL = true;
            Debug.Log("Left" + leftdirection);
        }
    }
}
