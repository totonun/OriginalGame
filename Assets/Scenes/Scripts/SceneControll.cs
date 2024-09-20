using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(SceneManager.GetActiveScene().name == "Title")
            {
                ToMain();
            }
            else if(SceneManager.GetActiveScene().name == "GameFinish")
            {
                ToResult();
            }
            else if (SceneManager.GetActiveScene().name == "Result")
            {
                ToTitle();
            }
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToResult()
    {
        SceneManager.LoadScene("Result");
    }
}
