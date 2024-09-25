using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{

    public float waitTime;
    public bool sceneChangeTrigger;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject;
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
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToResult()
    {
        SceneManager.LoadScene("Result");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ToPrepareStart()
    {
        SceneManager.LoadScene("PrepareStart");
    }

    public void ToDescliption()
    {
        SceneManager.LoadScene("Descliption");
    }

    public void ToGameFinish()
    {
        SceneManager.LoadScene("GameFinish");
    }

    // コルーチン関数
    IEnumerator WaitAndExecute()
    {
        // 待つ
        yield return new WaitForSeconds(waitTime);

        // 経過後に呼ばれる処理
        sceneChangeTrigger = true;
    }
}
