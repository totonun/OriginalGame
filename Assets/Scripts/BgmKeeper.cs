using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmKeeper : MonoBehaviour
{
    private AudioSource audioSource;
    private bool destroyTrigger;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        destroyTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "PrepareStart")
        {
            destroyTrigger = true;
        }

        if (destroyTrigger)
        {
            Destroy(this.gameObject);
            destroyTrigger = false;
        }
    }
}
