using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NecromancerFlyAway : MonoBehaviour
{
    public GameObject necromancer;
    public Animator animator;
    public Camera cam;
    public Rigidbody2D rbody;

    public bool isTriggered = false;
    private void Start()
    {
        necromancer = GameObject.Find("Necromancer");
        animator = GameObject.Find("Necromancer").GetComponent<Animator>();
        rbody = GameObject.Find("Necromancer").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = true;
            animator.SetBool("Moving", true);           
            StartCoroutine(StopNecroFly());
        }
    }

    IEnumerator StopNecroFly()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("Moving", false);
        rbody.velocity = new Vector2(0, -2);
        yield return new WaitForSeconds(2);
        rbody.velocity = new Vector2(0, 0);
        necromancer.SetActive(false);
        isTriggered = false;
        this.gameObject.SetActive(false);
        
    }
}
