using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //References
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;

    //Health, dying, etc
    public int health = 3;

    //Speeds based on which axis is being moved on
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    //Push
    protected Vector3 pushDirection;
    public float pushRecoverySpeed = 0.2f;

    //immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Logic
    public float triggerLength = 0.3f;
    public float chaseLength = 1f;
    private bool chasing; //are you chasing player?
    private bool collidingWithPlayer; //way to know if currently colliding
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        //is the player in range?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //checking for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            //the array is not cleaned up, so we do it ourselves
            hits[i] = null;
        }
    }


    private void UpdateMotor(Vector3 input)
    {
        // reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //swap sprite direction, wether youre going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Add push vector if any
        moveDelta += pushDirection;

        //Reduce pushforce every frame based off of recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // make sure we can move in this direction Y axis by casting a box there first, if its null we can move there
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make it move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // make sure we can move in this direction X axis by casting a box there first, if its null we can move there
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make it move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
    private void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            health -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce; //pushes away from the origin of dmg * pushforce

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f); //shows dmg text

            if (health <= 0)
            {
                health = 0;
                Death();
            }
        }
    }
    private void Death()
    {

    }
}





