using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject weapon;

    private BoxCollider2D bc2D;
    private PlayerMover player;


    private void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
        player = GetComponent<PlayerMover>();
    }


    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            weapon.transform.parent = weaponSlot;
            bc2D.size = new Vector2(0.07f, 0.42f);
            bc2D.offset = new Vector2(0, 0.1f);
            weapon.transform.position = weaponSlot.position;

            switch (player.axis)
            {
                case 0:
                    weapon.transform.position = weaponSlot.position;
                    break;
                case 1:
                    if (player.lookingLeft)
                    {
                        weapon.transform.position = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        weapon.transform.position = weaponSlot.position;
                    }
                    break;
                case 2:
                    weapon.transform.position = -weaponSlot.position;
                    break;
            }

           
        }
    }*/
}
