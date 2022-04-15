using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    //public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //teleport the player
            //GameManager.instance.SaveState();
            //string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            coll.transform.position = new Vector3(0, 13.25f, 0);
        }
        
    }
}
