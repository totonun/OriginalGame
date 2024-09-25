using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject rightScale;
    public GameObject leftScale;
    public GameObject weightController;

    public bool isGravity;

    public GameObject gameManager;

    Rigidbody2D rb;
    SceneControll sc;
    AudioSource audioSource;

    public bool isFallSound;
    public bool scaleFallTrigger;
    public bool isRbSet;

    // Start is called before the first frame update
    void Start()
    {
        isGravity = false;
        gameManager = this.gameObject;
        sc = gameManager.GetComponent<SceneControll>();
        audioSource = gameManager.GetComponent<AudioSource>();
        isFallSound = false;
        scaleFallTrigger = false;
        isRbSet = false;
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log("GameOver");
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
        audioSource.Play();
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
}
