using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public BackgroundMusic music;

    void Start()
    {
        music = GameObject.Find("BackgroundMusic").GetComponent<BackgroundMusic>();    
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //teleport the player
            //GameManager.instance.SaveState();
            //string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            coll.transform.position = new Vector3(0, 13.25f, 0);
            music.PlayForest();
        }
        
    }
}
