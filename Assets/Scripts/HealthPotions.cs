using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotions : MonoBehaviour
{
    public PlayerMover playerMover;
    public GameObject potion01;
    public GameObject potion02;
    public GameObject potion03;
    public HealthBar healthBar;

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        playerMover = GameObject.Find("Player").GetComponent<PlayerMover>();
        potion01 = GameObject.Find("HPBottle01");
        potion02 = GameObject.Find("HPBottle02");
        potion03 = GameObject.Find("HPBottle03");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerMover.potion > 0)
            {
                playerMover.currentHealth += 2;
                healthBar.SetHealth(playerMover.currentHealth);
                if (playerMover.potion == 3)
                    potion03.SetActive(false);
                else if (playerMover.potion == 2)
                    potion02.SetActive(false);
                else if (playerMover.potion == 1)
                    potion01.SetActive(false);
                playerMover.potion--;
            }
        }
        if (playerMover.potion == 0)
        {
            potion01.SetActive(false);
            potion02.SetActive(false);
            potion03.SetActive(false);
        }
        else if (playerMover.potion > 0)
        {
            ShowPotion();
        }
    }

    public void ShowPotion()
    {
        if (playerMover.potion == 1)
        {
            potion01.SetActive(true);
            potion02.SetActive(false);
            potion03.SetActive(false);
        }
        else if (playerMover.potion == 2)
        {
            potion01.SetActive(true);
            potion02.SetActive(true);
            potion03.SetActive(false);
        }
        else if (playerMover.potion == 3)
        {
            potion01.SetActive(true);
            potion02.SetActive(true);
            potion03.SetActive(true);
        }
    }

}
