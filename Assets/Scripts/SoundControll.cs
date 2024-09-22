using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundControll : MonoBehaviour
{
    public AudioSource audioSource;
    //public bool isClickPlaying;
    public bool clickPlayTrigger;
    public bool clickPlayStart;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = this.gameObject.GetComponent<AudioSource>();
        //isClickPlaying = audioSource.isPlaying;
        clickPlayTrigger = false;
        clickPlayStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            clickPlayTrigger = true;
            clickPlayStart = true;
        }
        if (clickPlayTrigger && clickPlayStart)
        {
            ClickSoundPlay();
            clickPlayStart = false;
        }
    }

    public void ClickSoundPlay()
    {
        audioSource.Play();
    }
}
