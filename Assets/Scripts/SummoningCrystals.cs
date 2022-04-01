using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningCrystals : MonoBehaviour
{
    public Animator animator;
    public int health = 5;

    bool isDead = false;
    float deathTime;

    //private Rigidbody2D rbody;

    void Start()
    {
        //rbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    public void getHurt()
    {
        animator.SetTrigger("TakeDamage");
        
        health--;
        if (health == 0)
        {
            Debug.Log("i'm dead :( ");
            StartCoroutine(Defeated());
        }
    }

    IEnumerator Defeated()
    {
        isDead = true;
        //axis = 0;
        //animator.SetInteger("Axis", axis);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsDying", true);
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(deathTime);

        Destroy(this.gameObject);
    }

}
