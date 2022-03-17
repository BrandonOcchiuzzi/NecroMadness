using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SkeletonPatterns : MonoBehaviour
{

    public float speed;

    public GameObject player;

    private Rigidbody2D rbody;

    public Animator animator;

    public int axis = 0;

    public bool lookingLeft = false;

    public AIPath aiPath;

    Path path;

    int currentWaypoint = 0;

    float nextWaypointDistance = 0.01f;

    bool reachedEndOfPath = false;

    bool currentlyColliding = false;


    Seeker seeker;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rbody = GetComponent<Rigidbody2D>();

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rbody.position, player.transform.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer();
    }

    /*     void thisShitDoesntWork(){
             if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }



            Vector2 directionToTarget = ((Vector2)path.vectorPath[currentWaypoint] - rbody.position).normalized;

            if (Mathf.Abs(directionToTarget.x) < Mathf.Abs(directionToTarget.y) && Mathf.Abs(directionToTarget.x) > Mathf.Epsilon)
            {
                directionToTarget.y = 0f;
            }
            else if (Mathf.Abs(directionToTarget.y) > Mathf.Epsilon)
            {
                directionToTarget.x = 0f;
            }

            if (directionToTarget.y == 0f)
            {
                if (player.transform.position.x > rbody.position.x)
                {
                    axis = 1;
                    lookingLeft = false;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = lookingLeft;
                }
                else
                {
                    axis = 1;
                    lookingLeft = true;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = lookingLeft;
                }
            }
            else
            {
                if (player.transform.position.y > rbody.position.y)
                {
                    axis = 2;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = false;

                }
                else
                {
                    axis = 0;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            Vector2 force = directionToTarget * speed * Time.deltaTime;

            Debug.Log("directionToTargetX " + directionToTarget.x);
            Debug.Log("directionToTargetY " + directionToTarget.y);

            rbody.AddForce (force);

            animator.SetFloat("Speed", Mathf.Abs(directionToTarget.x + directionToTarget.y));


            float distance = Vector2.Distance(rbody.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        } */

    void FixedUpdate()
    {

    }

    void detectPlayer()
    {
        Transform playerTransform = player.GetComponent<Transform>();

        Vector3 playerPosition = playerTransform.position;

        float dist = Vector3.Distance(playerPosition, rbody.position);

        float playerAxis = player.GetComponent<PlayerMover>().axis;

        bool playerDirection = player.GetComponent<PlayerMover>().lookingLeft;

        Vector3 width = GetComponent<CapsuleCollider2D>().bounds.size;

        Vector3 directionToTarget = playerPosition - transform.position;

        if (dist < 0.7)
        {

            if (Mathf.Abs(directionToTarget.x) < Mathf.Abs(directionToTarget.y) && Mathf.Abs(directionToTarget.x) > Mathf.Epsilon)
            {
                if (currentlyColliding)
                {
                    directionToTarget.x = 0f;
                }
                else
                {
                    directionToTarget.y = 0f;
                }
            }
            else if (Mathf.Abs(directionToTarget.y) > Mathf.Epsilon)
            {
                if (currentlyColliding)
                {
                    directionToTarget.y = 0f;
                }
                else
                {
                    directionToTarget.x = 0f;
                }
            }

            if (directionToTarget.y == 0f)
            {
                if (playerPosition.x > transform.position.x)
                {
                    axis = 1;
                    lookingLeft = false;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = lookingLeft;
                }
                else
                {
                    axis = 1;
                    lookingLeft = true;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = lookingLeft;
                }
            }
            else
            {
                if (playerPosition.y > transform.position.y)
                {
                    axis = 2;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = false;

                }
                else
                {
                    axis = 0;
                    animator.SetInteger("Axis", axis);
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                transform.position + directionToTarget,
                speed * Time.deltaTime
            );

            animator.SetFloat("Speed", Mathf.Abs(directionToTarget.x + directionToTarget.y));

        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("other name" + other.gameObject.name);

        if (other.gameObject.name == "Solid Objects")
        {
            currentlyColliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Solid Objects")
        {
            currentlyColliding = false;
        }
    }
}
