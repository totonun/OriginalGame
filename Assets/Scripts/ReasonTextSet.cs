using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReasonTextSet : MonoBehaviour
{
    public Text reasonText;

    // Start is called before the first frame update
    void Start()
    {
        reasonText.text = SceneControll.reasonString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
