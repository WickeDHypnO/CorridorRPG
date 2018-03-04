using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    public Animator animator;

	public void PlayAttack () {
        animator.Play("Attack");
	}

    public void PlayDeath()
    {
        animator.Play("Death");
    }

    public void PlayHit()
    {
        animator.Play("Hit");
    }
}
