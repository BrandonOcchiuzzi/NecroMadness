using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rbody;

    public Animator animator;

    public float attackRangeX = 0.1f;

    public float attackRangeY = 0.1f;


    public Transform attackFront;

    public Transform attackBack;

    public Transform attackRight;

    public Transform attackLeft;

    public LayerMask enemyLayers;

    //To change weaponslot position as per player movement
    public Transform weaponSlot;

    [SerializeField]
    private float speed = 5.0f;

    float horizontalMove = 0f;

    public bool attack = false;

    public int axis = 0;

    public bool lookingLeft = false;
    private bool m_Pressed;

    //Health, Damage, Healing
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;


    Vector2 moveDirection = Vector2.zero;

    Vector2 lastVelocity = Vector2.zero;
    private PlayerController playerController;

    public float attackTime;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        UpdateAnimClipTimes();

        currentHealth = maxHealth; //sets hp to maxHealth upon load
        healthBar.SetMaxHealth(maxHealth); //SetMaxHealth Method in healthbar script
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
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

        //*************************************************************
        if (Input.GetKeyDown(KeyCode.Tab)) //just for testing of HP bar
        {                                  //with taking damage. 
            TakeDamage(1);
        }
        //*************************************************************
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            if (currentHealth < 5)
            {
                currentHealth += 5;
                healthBar.SetHealth(currentHealth);
            }
            else
            {
                currentHealth = maxHealth;
                healthBar.SetHealth(currentHealth);
            }
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage) //allows taking of damage and passes it to the health bar
    {
        currentHealth -= damage; //sets current health based on dmg taken
        healthBar.SetHealth(currentHealth); //SetHealth Method in HealthBar Script
    }



    private void Attack(InputAction.CallbackContext context)
    {
        if (!attack)
        {
            attack = true;
            animator.SetBool("isAttacking", true);
            StartCoroutine(StopAnim());
        }

    }

    IEnumerator StopAnim()
    {
        float tempSpeed = speed;

        speed = 0;

        Vector2 attackRange = new Vector2(attackRangeX, attackRangeY);

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackFront.position, attackRange, enemyLayers);


        switch (axis)
        {
            case 0:
                Debug.Log("front");
                
                hitEnemies = Physics2D.OverlapBoxAll(attackFront.position, attackRange, enemyLayers);
                break;

            case 1:
                attackRange = new Vector2(attackRangeY, attackRangeX);

                if (lookingLeft)
                {
                    Debug.Log("left");

                    hitEnemies = Physics2D.OverlapBoxAll(attackLeft.position, attackRange, enemyLayers);
                }
                else
                {
                    Debug.Log("right");
                    
                    hitEnemies = Physics2D.OverlapBoxAll(attackRight.position, attackRange, enemyLayers);
                }
                break;

            case 2:
                Debug.Log("back");
                
                hitEnemies = Physics2D.OverlapBoxAll(attackBack.position, attackRange, enemyLayers);

                break;
        }
        

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "enemy")
            {
                enemy.GetComponent<SkeletonPatterns>().getHurt();
            }
        }


        yield return new WaitForSeconds(attackTime);

        speed = tempSpeed;


        animator.SetBool("isAttacking", false);
        attack = false;
    }

    private void AttackStopped(InputAction.CallbackContext context)
    {

    }

    void OnDrawGizmosSelected()
    {

        Vector2 attackRange = new Vector2(attackRangeX, attackRangeY);


        switch (axis)
        {
            case 0:
                Gizmos.DrawCube(attackFront.position, attackRange);

                break;

            case 1:
                attackRange = new Vector2(attackRangeY, attackRangeX);

                if (lookingLeft)
                {

                    Gizmos.DrawCube(attackLeft.position, attackRange);
                }
                else
                {
                    Gizmos.DrawCube(attackRight.position, attackRange);
                }
                break;

            case 2:
                Gizmos.DrawCube(attackBack.position, attackRange);

                break;
        }
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
            weaponSlot.transform.localPosition = new Vector3(0, -0.035f, 0);
            weaponSlot.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rbody.velocity.x < 0)
        {
            axis = 1;
            animator.SetInteger("Axis", axis);
            lookingLeft = true;
            GetComponent<SpriteRenderer>().flipX = lookingLeft;
            weaponSlot.transform.localPosition = new Vector3(0f, -0.035f, 0);
            weaponSlot.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        else if (rbody.velocity.y > 0)
        {
            axis = 2;
            animator.SetInteger("Axis", axis);
            GetComponent<SpriteRenderer>().flipX = false;
            weaponSlot.transform.localPosition = new Vector3(0.05f, -0.035f, 0);
            weaponSlot.transform.localRotation = Quaternion.Euler(0, 70, 0);
        }

        else if (rbody.velocity.y < 0)
        {
            axis = 0;
            animator.SetInteger("Axis", axis);
            GetComponent<SpriteRenderer>().flipX = false;
            weaponSlot.transform.localPosition = new Vector3(-0.05f, -0.035f, 0);
            weaponSlot.transform.localRotation = Quaternion.Euler(0, 70, 0);
        }

        animator.SetFloat("Speed", Mathf.Abs(rbody.velocity.x + rbody.velocity.y));

    }

}
