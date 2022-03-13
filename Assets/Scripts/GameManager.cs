using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null) //ensures there is never more than 1 game mananger
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject); //ensures the game manager stays around scene to scene
    }

    //Resources
    //public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    //public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerMover player;

    //Logic
    public int pesos;
    public int experience;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveState()
    {
        Debug.Log("SaveState");
        string s = "";

        s += "0" + "|";
        //s += pesos.ToString() + "|";
        //s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    //load game
    public void LoadState(Scene s, LoadSceneMode mode)

    {

        Debug.Log("LoadState");


        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|'); //single quotes calls the character, not "" for string
        // change player skin
       
        //pesos = int.Parse(data[1]); //casting the string of pesos to int
        
        //experience = int.Parse(data[2]); //casting the string of experience to int
        
        // change the weapon level

    }
}
