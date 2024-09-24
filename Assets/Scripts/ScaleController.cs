using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject rightScale;
    public GameObject leftScale;
    public GameObject weightController;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.GetComponent<CompareWeight>().tooHeavyTrigger());
        if (gameObject.GetComponent<CompareWeight>().tooHeavyTrigger())
        {
            Debug.Log("Trigger");
            if(WeightControll.rightSideWeight > WeightControll.leftSideWeight)
            {
                addGravity(rightScale);
                Debug.Log("Added");
            }
            else
            {
                addGravity(leftScale);
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
        rb.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
    }
}
