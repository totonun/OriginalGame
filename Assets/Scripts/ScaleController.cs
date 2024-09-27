using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    public GameObject rightScale;
    public GameObject leftScale;
    public GameObject weightController;

    public bool isGravity;

    public GameObject gameManager;
    private GameObject moveObject;

    Rigidbody2D rb;
    SceneControll sc;
    //AudioSource audioSource;

    public bool isFallSound;
    public bool isRbSet;
    private bool moveTrigger;

    public Text clickText;
    private bool isMoveFinish;

    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        isGravity = false;
        gameManager = this.gameObject;
        sc = gameManager.GetComponent<SceneControll>();
        //audioSource = gameManager.GetComponent<AudioSource>();
        isFallSound = false;
        //scaleFallTrigger = false;
        isRbSet = false;
        isMoveFinish = false;
        moveTrigger = false;

        if (SceneManager.GetActiveScene().name == "Result")
        {
            clickText.enabled = false;
            if (CompareWeight.persentage == 0)
            {
                isMoveFinish = true;
            }
            else
            {
                rankMoveSet();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            if (!isRbSet)
            {
                if (gameObject.GetComponent<CompareWeight>().tooHeavyTrigger())
                {
                    if (WeightControll.rightSideWeight > WeightControll.leftSideWeight)
                    {
                        addGravity(rightScale);
                    }
                    else
                    {
                        addGravity(leftScale);
                    }
                }
            }
            else
            {
                if (isGravity)
                {
                    sc.GameOver();
                }
                else if (WeightControll.rightSideWeight > WeightControll.leftSideWeight)
                {
                    addForce(rightScale);
                }
                else
                {
                    addForce(leftScale);
                }
            }
        }

        else if(SceneManager.GetActiveScene().name == "Result")
        {
            if (moveTrigger)
            {                
                //moveObject.transform.position -= new Vector3(0, 80, 0) * Time.deltaTime;
                //Debug.Log(originalPos.y - moveObject.transform.position.y);
                
                if ((originalPos.y - moveObject.transform.position.y)  > (100 -CompareWeight.persentage)  / 3)
                {
                    Debug.Log("Stop");
                    moveTrigger = false;
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;

                    isMoveFinish = true;
                }
                
            }
            if (isMoveFinish)
            {
                clickText.enabled = true;
                if (Input.GetMouseButtonUp(0))
                {
                    SceneManager.LoadScene("Bonus");
                }
            }
        }

    }

    private void changePos(GameObject pObject)
    {
        Vector3 position = pObject.transform.position;
        position.z -= Time.deltaTime;
        pObject.transform.position = position;
    }

    private void addGravity(GameObject pObject)
    {
        rb = pObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isRbSet = true;
        //audioSource.Play();
    }

    private void addForce(GameObject pObject)
    {
        rb = pObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
        if (pObject.transform.position.y < -220f)
        {
            isGravity = true;
        }
    }

    private void rankMoveSet()
    {
        if (WeightControll.rightSideWeight > WeightControll.leftSideWeight)
        {
            moveObject = rightScale;
        } 
        else
        {
            moveObject = leftScale;
        }

        originalPos = new Vector3(moveObject.transform.position.x, moveObject.transform.position.y, moveObject.transform.position.z);
        rb = moveObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        rb.AddForce(new Vector2(0, 40), ForceMode2D.Impulse);
        rb.velocity = new Vector2(0, -5);
        //audioSource.Play();
        moveTrigger = true;
    }
}
