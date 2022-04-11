using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    PlayerMover player;
    public int heal;

    private void OnCollision2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            HeartHeal();
        }
    }
    public void HeartHeal()
    {
        //gain amount of health as specified on the prefab
        player.currentHealth += heal;
        
        //destroy the heart
        Destroy(this.gameObject);
        
    }
}
