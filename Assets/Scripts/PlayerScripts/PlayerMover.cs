using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rbody;

    public Animator animator;

    [SerializeField]
    private float speed = 5.0f;

    float horizontalMove = 0f;

    bool attack = false;

    Vector2 moveDirection = Vector2.zero;

    Vector2 lastVelocity = Vector2.zero;
    private PlayerController playerController;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        playerController = new PlayerController();
    }

    void OnEnable()
    {
        playerController.Enable();
    }

    void OnDisable()
    {
        playerController.Disable();
    }

    private void Update()
    {
        moveDirection = playerController.Default.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (moveDirection.x == 0 || moveDirection.y == 0)
        {
            Debug.Log("FIRST IF");
            rbody.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime);
            lastVelocity = rbody.velocity;
        }
        else
        {
            Debug.Log("ELSE STATEMENT");
            rbody.velocity = lastVelocity;
        }

        if (rbody.velocity.x > 0)
        {
            Debug.Log("velocity x" + rbody.velocity.x);
            animator.SetInteger("Axis", 1);
            Debug.Log("animator " + animator.GetInteger("Axis"));

            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rbody.velocity.x < 0)
        {
            Debug.Log("velocity x" + rbody.velocity.x);
            animator.SetInteger("Axis", 1);
            Debug.Log("animator " + animator.GetInteger("Axis"));

            GetComponent<SpriteRenderer>().flipX = true;
        }

        else if (rbody.velocity.y > 0)
        {
            Debug.Log("velocity y" + rbody.velocity.y);
            animator.SetInteger("Axis", 2);
            Debug.Log("animator " + animator.GetInteger("Axis"));

            GetComponent<SpriteRenderer>().flipX = true;
        }

        else if (rbody.velocity.y < 0)
        {
            Debug.Log("velocity y" + rbody.velocity.y);
            animator.SetInteger("Axis", 0);
            Debug.Log("animator " + animator.GetInteger("Axis"));

            GetComponent<SpriteRenderer>().flipX = true;
        }


        animator.SetFloat("Speed", Mathf.Abs(rbody.velocity.x + rbody.velocity.y));

    }

}
