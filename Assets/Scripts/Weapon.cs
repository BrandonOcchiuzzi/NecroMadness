using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject weapon;
    public Animator animator;

    private BoxCollider2D bc2D;
    private PlayerMover player;

    private PlayerController playerController;

    private bool attack;
    private bool weaponPicked;

    private void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").GetComponent<PlayerMover>();
        playerController = new PlayerController();
        animator = gameObject.GetComponent<Animator>();
        weaponPicked = false;
    }

    void FixedUpdate()
    {
        if (weaponPicked == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                attack = true;
            }
            else
            {
                attack = false;
            }

            if (attack == false)
            {
                animator.SetBool("isAttacking", false);
            }

            if (attack == true)
            {
                animator.SetBool("isAttacking", true);
            }

            switch (player.axis)
            {
                case 0:
                    animator.SetInteger("Axis", 0);
                    break;
                case 1:
                    if (player.lookingLeft)
                    {
                        animator.SetInteger("Axis", 2);
                    }
                    else
                    {
                        animator.SetInteger("Axis", 1);
                    }
                    break;
                case 2:
                    animator.SetInteger("Axis", 3);
                    break;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            weapon.transform.parent = weaponSlot;
            bc2D.size = new Vector2(0.07f, 0.42f);
            bc2D.offset = new Vector2(0, 0.1f);
            weapon.transform.position = weaponSlot.position;
            weaponPicked = true;

            /*switch (player.axis)
            {
                case 0:
                    weaponSlot.transform.localPosition = new Vector3(-0.05f, -0.035f, 0);
                    weaponSlot.transform.localRotation = Quaternion.Euler(0, 70, 0);
                    break;
                case 1:
                    if (player.lookingLeft)
                    {
                        weaponSlot.transform.localPosition = new Vector3(-0.05f, -0.035f, 0);
                        weaponSlot.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        weaponSlot.transform.localPosition = new Vector3(0, -0.035f, 0);
                        weaponSlot.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                    break;
                case 2:
                    weaponSlot.transform.localPosition = new Vector3(0.05f, -0.035f, 0);
                    weaponSlot.transform.localRotation = Quaternion.Euler(0, 70, 0);
                    break;
            }*/

           
        }
    }

}
