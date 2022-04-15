using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip villageMusic;
    public AudioClip forestMusic;
    public AudioClip catacombsMusic;

    public AudioSource audioSource;

    void Awake()
    {
        //villageMusic = GetComponent<AudioClip>();
        //forestMusic = GetComponent<AudioClip>();
        //catacombsMusic = GetComponent<AudioClip>();
        audioSource.clip = villageMusic;
        audioSource.Play();
    }
    public void PlayVillage()
    {
        audioSource.clip = villageMusic;
        audioSource.Play();
    }

    public void PlayForest()
    {
        audioSource.clip = forestMusic;
        audioSource.Play();
    }

    public void PlayCatacombs()
    {
        audioSource.clip = catacombsMusic;
        audioSource.Play();
    }
}
