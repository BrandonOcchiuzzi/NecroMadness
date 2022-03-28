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
    private Rigidbody2D rbody;
    private SpriteRenderer spriteRenderer;

    private PlayerController playerController;

    //Vector2 moveDirection = Vector2.zero;
    //Vector2 lastVelocity = Vector2.zero;

    //private bool attack;
    private bool weaponPicked;
    //private float speed = 50;
    //private float startTime = 0;
    //private float holdTime = 0.21f;

    private void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<PlayerMover>();
        playerController = new PlayerController();
        animator = gameObject.GetComponent<Animator>();
        weaponPicked = false;
        rbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //moveDirection = playerController.Default.Move.ReadValue<Vector2>();
        if (weaponPicked == true)
        {
            animator.SetBool("isAttacking", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isAttacking", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            weapon.transform.SetParent(weaponSlot, false);
            bc2D.size = new Vector2(0.07f, 0.42f);
            bc2D.offset = new Vector2(0, 0.1f);
            weapon.transform.position = weaponSlot.position;
            weaponPicked = true;
        }
    }

    void FixedUpdate()
    {
        if (weaponPicked == true)
        {
            animator.SetBool("Picked", true);

            animator.SetFloat("Speed", Mathf.Abs(player.velocityX + rbody.velocity.y));

            /*if (rbody.velocity.x == 0 || rbody.velocity.y == 0)
            {
                animator.SetFloat("Speed", rbody.velocity.x);
            }
            if (rbody.velocity.x == 0 && rbody.velocity.y == 0)
            {
                animator.SetFloat("Speed", rbody.velocity.x);
            }
            else if (rbody.velocity.x > 0)
            {
                animator.SetFloat("Speed", 1);
            }
            else if (rbody.velocity.x < 0)
            {
                animator.SetFloat("Speed", -1);
            }
            else if (rbody.velocity.y > 0)
            {
                animator.SetFloat("Speed", rbody.velocity.y);
            }
            else if (rbody.velocity.y < 0)
            {
                animator.SetFloat("Speed", rbody.velocity.y);
            }
            */



            switch (player.axis)
            {
                case 0:
                    animator.SetInteger("Axis", 0);
                    spriteRenderer.sortingLayerName = "Weapon";
                    break;
                case 1:
                    if (player.lookingLeft)
                    {
                        animator.SetInteger("Axis", 2);
                        spriteRenderer.sortingLayerName = "WeaponBehind";
                    }
                    else
                    {
                        animator.SetInteger("Axis", 1);
                        spriteRenderer.sortingLayerName = "Weapon";
                    }
                    break;
                case 2:
                    animator.SetInteger("Axis", 3);
                    spriteRenderer.sortingLayerName = "WeaponBehind";
                    break;
            }
        }
    }
}
