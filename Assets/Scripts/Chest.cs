using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite emptyChest;
    //public int GoldAmount = 10;
    public PlayerMover player;
    public bool collected = false;
    public FloatTextManager floatTextManager;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMover>();
        floatTextManager = GameObject.Find("FloatTextManager").GetComponent<FloatTextManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!collected && player.potion <= 3)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                floatTextManager.Show("+ HP Bottle!", 50, Color.red, transform.position, Vector3.up * 25, 1.5f);
                player.potion++;
            }
        }
    }
}
