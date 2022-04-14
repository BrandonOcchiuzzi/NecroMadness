using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void restartBtn()
    {
        SceneManager.LoadScene("NewVillage");
    }

    public void exitBtn()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
