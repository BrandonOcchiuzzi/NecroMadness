using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int GoldAmount = 10;


   protected override void OnCollect()
   {
       if (!collected)
       {
           collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + GoldAmount + " Gold!" ,30 , Color.yellow, transform.position, Vector3.up * 25, 1.5f );
       }       
   }
}
