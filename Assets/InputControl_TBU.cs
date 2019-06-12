using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InputControl_TBU : MonoBehaviour {

    public VideoPlayer Clip1;
    public AudioClip audio1;
    public AudioSource audioPlayer;
    public AudioSource ambientSoundPlayer;
    public GameObject loadingScreen;
    public GameObject CameraImageObj;

    int step = 0;

    bool clipHasPlayed = false;
    bool clipHasPrepared = false;
    bool clipHasDestroyed = false;

    // Use this for initialization
    void Start () {
        if (!Clip1)
            Debug.LogError("clip1 not exist");
        if (!loadingScreen)
            Debug.LogError("loadingscreen not exist");

    }

    // Update is called once per frame
    void Update()
    {
        if (!clipHasDestroyed && Clip1.isPrepared)
        {
            clipHasPrepared = true;
        }
        if (Input.GetKeyDown("space"))
        {
            
            switch (step)
            {
                case 0:
                    if (clipHasPlayed)
                    {
                        clipHasPrepared = true;
                        
                    }
                    loadingScreen.SetActive(false);
                    Clip1.Play();
                    clipHasPlayed = true;
                    break;
                case 1:
                    
                    if (audioPlayer && audio1)
                    {
                        audioPlayer.clip = audio1;
                        audioPlayer.loop = true;
                        audioPlayer.Play();
                    } else
                    {
                        Debug.LogError("audioPlayer or audio1 not exist");
                    }
                    if (ambientSoundPlayer)
                    {
                        ambientSoundPlayer.Play();
                    }
                    else
                    {
                        Debug.LogError("ambientSoundPlayer not exist");
                    }
                    step += 1;
                    break;
                case 2:
                    
                    audioPlayer.Stop();
                    ambientSoundPlayer.Stop();
                    break;
            } 
        }
        
        if (clipHasPlayed && clipHasPrepared && !clipHasDestroyed)
        {
            if (!Clip1.isPlaying)
            {
                Destroy(Clip1);
                clipHasDestroyed = true;
                step += 1;
                loadingScreen.SetActive(true);
                CameraImageObj.SetActive(true);
            }
        }

    }
}
