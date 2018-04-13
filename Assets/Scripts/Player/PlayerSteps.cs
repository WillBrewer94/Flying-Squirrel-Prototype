using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour {

    public AudioClip footStepAudio;
    public AudioClip flyingAudio;

    AudioSource audioSource;



    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // play a footstep sound
    public void playFootStep()
    {
        audioSource.PlayOneShot(footStepAudio, Random.Range(0.5f, 0.8f));
    }

    // play a wing flap sound
    public void playFlyingSound()
    {
        audioSource.PlayOneShot(flyingAudio, Random.Range(0.5f, 0.8f));
    }
}
