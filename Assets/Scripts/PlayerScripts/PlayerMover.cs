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

    public bool attack = false;

    public int axis = 0;

    public bool lookingLeft = false;
    private bool m_Pressed;


    Vector2 moveDirection = Vector2.zero;

    Vector2 lastVelocity = Vector2.zero;
    private PlayerController playerController;

    public float attackTime;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        UpdateAnimClipTimes();
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "player_attack_front":
                    attackTime = clip.length;
                    break;
            }
        }
    }

    void Awake()
    {
        playerController = new PlayerController();
    }

    void OnEnable()
    {
        playerController.Enable();

        playerController.Default.Attack.performed += Attack;

        playerController.Default.Attack.canceled += AttackStopped;

    }

    void OnDisable()
    {
        playerController.Disable();
    }

    private void Update()
    {
        moveDirection = playerController.Default.Move.ReadValue<Vector2>();
    }


    private void Attack(InputAction.CallbackContext context)
    {
        animator.SetBool("isAttacking", true);
        StartCoroutine(StopAnim());
    }

    IEnumerator StopAnim()
    {
        float tempSpeed = speed;


        speed = 0;

        yield return new WaitForSeconds(attackTime);

        speed = tempSpeed;

        animator.SetBool("isAttacking", false);
    }

    private void AttackStopped(InputAction.CallbackContext context)
    {

    }

    void FixedUpdate()
    {

        if (moveDirection.x == 0 || moveDirection.y == 0)
        {
            rbody.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime);
            lastVelocity = rbody.velocity;
        }
        else
        {
            rbody.velocity = lastVelocity;
        }

        if (rbody.velocity.x > 0)
        {
            axis = 1;
            animator.SetInteger("Axis", axis);
            lookingLeft = false;
            GetComponent<SpriteRenderer>().flipX = lookingLeft;
        }
        else if (rbody.velocity.x < 0)
        {
            axis = 1;
            animator.SetInteger("Axis", axis);
            lookingLeft = true;
            GetComponent<SpriteRenderer>().flipX = lookingLeft;
        }

        else if (rbody.velocity.y > 0)
        {
            axis = 2;
            animator.SetInteger("Axis", axis);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if (rbody.velocity.y < 0)
        {
            axis = 0;
            animator.SetInteger("Axis", axis);
            GetComponent<SpriteRenderer>().flipX = false;
        }


        animator.SetFloat("Speed", Mathf.Abs(rbody.velocity.x + rbody.velocity.y));

    }

}
