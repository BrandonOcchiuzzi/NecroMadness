using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collidable
{
    PlayerMover player;
    public int heal;
    public void HeartHeal()
    {
        //gain amount of health as specified on the prefab
        player.currentHealth += heal;
        
        //destroy the heart
        Destroy(this.gameObject);
        
    }
}
