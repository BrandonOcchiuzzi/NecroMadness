using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void PlayGame()
    {
        SceneManager.LoadScene("NewVillage");
    }

    public void QuitGame()
    {
        Debug.Log("EXIT!");
        Application.Quit();
    }

    public void SetMusic (float music)
    {
        audioMixer.SetFloat("music", music);
    }
    public void SetSound(float sound)
    {
        audioMixer.SetFloat("sound", sound);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
