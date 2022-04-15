using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroMancerPatterns : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDefeated = false;

    public bool isAttacking = false;

    public int health = 4;

    float attackTime;

    float deathTime;

    public Animator animator;

    public GameObject fireball;

    public GameObject player;

    void Start()
    {
        UpdateAnimClipTimes();
        InvokeRepeating("callAttack", 2f, 1.5f);
    }

    public void callAttack()
    {
        if (!isDefeated)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", isAttacking);

        Vector3 lookTarget =
            (player.GetComponent<Transform>().position - transform.position)
                .normalized;

        float angle = Mathf.Atan2(lookTarget.y, lookTarget.x) * Mathf.Rad2Deg;

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle);

        GameObject fb = Instantiate(fireball, transform.position, rotation);
        fb.transform.SetParent(transform.parent, true);

        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }

    IEnumerator Dying()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
        isDefeated = true;
        animator.SetBool("isDying", isDefeated);

        yield return new WaitForSeconds(attackTime);

        Destroy(this.gameObject);
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips =
            animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Necromancer_attack":
                    attackTime = clip.length;
                    break;
                case "Necromancer_death":
                    deathTime = clip.length;
                    break;
            }
        }
    }

    public void onCrystalDestroyed()
    {
        health--;
        if (health == 0)
        {
            StartCoroutine(Dying());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
