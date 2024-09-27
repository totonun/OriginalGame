using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{

    public float waitTime;
    public bool sceneChangeTrigger;

    public GameObject gameManager;
    public GameObject weightControll;

    public static string reasonString;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject;
        weightControll = GameObject.Find("WeightControll");
        waitTime = 1.0f;
        sceneChangeTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(SceneManager.GetActiveScene().name == "Open")
            {
                ToTitle();
            }
            else if(SceneManager.GetActiveScene().name == "Title")
            {
                ToDescliption();
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
        ReleaseItem.isItem = false;
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToResult()
    {
        SceneManager.LoadScene("Result");
    }

    public void GameOver(string reason)
    {
        reasonString = reason;
        SceneManager.LoadScene("GameOver");
        DifficultySet.playCount--;
    }

    public void ToPrepareStart()
    {
        SceneManager.LoadScene("PrepareStart");
        WeightControll.leftSideWeight = 0;
        WeightControll.rightSideWeight = 0;
        WeightControll.weightDifference = 0;
        CompareWeight.maxWeight = 0;
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
