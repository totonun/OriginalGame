using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMaxScore : MonoBehaviour
{
    public Text maxScoreText;
    public static int maxPersentage;

    // Start is called before the first frame update
    void Start()
    {
        if(DifficultySet.playCount == 0)
        {
            maxScoreText.enabled = false;
        }
        else
        {
            maxScoreText.enabled = true;
            maxScoreText.text = "ç≈çÇãLò^: " + maxPersentage.ToString() + " %";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
