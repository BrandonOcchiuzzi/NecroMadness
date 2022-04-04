using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SummoningCrystals : MonoBehaviour
{
    //References
    public Animator animator;
    private Rigidbody2D rBody;
    

    //Health, Damage, Healing, Death
    public int health = 5;
    bool isDying = false;
    float deathTime;

    public int axis = 0;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        
    }

    public void getHurt()
    {
        animator.SetTrigger("TakeDamage");
        //Vector3 direction = (transform.position - GameObject.FindWithTag("Player").transform.position).normalized;
                
        if (health == 0)
        {
            Debug.Log("i'm dead :( ");
            StartCoroutine(Defeated());
        }
    }

    IEnumerator Defeated()
    {
        isDying = true;
        axis = 0;
        animator.SetInteger("Axis", axis);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsDying", true);
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(deathTime);

        Destroy(this.gameObject);
    }

}
