using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void restartBtn()
    {
        SceneManager.LoadScene("NewVillage");
        player.transform.position = new Vector2(-3f, 2.7f);
    }

    public void exitBtn()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
