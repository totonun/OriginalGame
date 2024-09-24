using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{

    public float waitTime;
    public bool sceneChangeTrigger;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 1.0f;
        sceneChangeTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(SceneManager.GetActiveScene().name == "Title")
            {
                ToDescliption();
            }
            else if (SceneManager.GetActiveScene().name == "Descliption")
            {
                ToPrepareStart();
            }
            else if(SceneManager.GetActiveScene().name == "GameFinish")
            {
                ToResult();
            }
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");

        /*
        StartCoroutine(WaitAndExecute());
        if (sceneChangeTrigger)
        {
            SceneManager.LoadScene("Title");
        }
        */
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");

        /*
        StartCoroutine(WaitAndExecute());
        if (sceneChangeTrigger)
        {
            SceneManager.LoadScene("Main");
        }
        */
    }

    public void ToResult()
    {
        SceneManager.LoadScene("Result");
        /*
        StartCoroutine(WaitAndExecute());
        if (sceneChangeTrigger)
        {
            SceneManager.LoadScene("Result");
        }
        */
    }

    public void ToPrepareStart()
    {
        SceneManager.LoadScene("PrepareStart");

        /*
        StartCoroutine(WaitAndExecute());
        if (sceneChangeTrigger)
        {
            SceneManager.LoadScene("PrepareStart");
        }
        */
    }

    public void ToDescliption()
    {
        SceneManager.LoadScene("Descliption");
    }

    // �R���[�`���֐�
    IEnumerator WaitAndExecute()
    {
        // �҂�
        yield return new WaitForSeconds(waitTime);

        // �o�ߌ�ɌĂ΂�鏈��
        sceneChangeTrigger = true;
    }
}
