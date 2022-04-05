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
    bool isGettingHurt = false;

    float deathTime;

    public int axis = 0;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        UpdateAnimClipTimes();

    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            Debug.Log("clip name" + clip.length);

            switch (clip.name)
            {

                case "CrystalExplosion":
                    deathTime = clip.length;
                    break;

            }
        }
    }


    void Update()
    {

    }

    public void getHurt()
    {

        if (!isGettingHurt)
        {
            isGettingHurt = true;
            animator.SetTrigger("TakeDamage");
            health--;

            Debug.Log("health " + health);
            //Vector3 direction = (transform.position - GameObject.FindWithTag("Player").transform.position).normalized;

            if (health == 0)
            {
                Debug.Log("i'm dead :( ");
                StartCoroutine(Defeated());
            }
            else
            {
                isGettingHurt = false;
            }
        }

    }

    IEnumerator Defeated()
    {
        GetComponent<Spawner>().isDying = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        Destroy(rBody);

        isDying = true;
        axis = 0;
        animator.SetInteger("Axis", axis);
        animator.SetBool("IsDead", true);
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(deathTime);

        Destroy(this.gameObject);
    }

}
