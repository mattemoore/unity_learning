using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMusic : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;
    private bool isPlaying = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBGMusic()
    {
        if (!isPlaying)
        {
            audioSource.Play();
            isPlaying = true;
        }
    }

    public void StopBGMusic()
    {
        audioSource.Stop();
        isPlaying = false;
    }

    public void SetVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
