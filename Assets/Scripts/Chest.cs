using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite emptyChest;
    //public int GoldAmount = 10;
    public PlayerMover playerMover;
    public bool collected = false;

    private void Start()
    {
        playerMover = GameObject.Find("Player").GetComponent<PlayerMover>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (!collected && playerMover.potion <= 3)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                GameManager.instance.ShowText("+ HP Bottle!", 50, Color.red, transform.position, Vector3.up * 25, 1.5f);
                playerMover.potion++;
            }
        }
    }
}
