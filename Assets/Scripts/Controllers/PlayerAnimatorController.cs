using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {
	private Animator animator;

	[SerializeField]
	private AudioSource audioShoot;

	void Start () {
		animator = GetComponent<Animator>();
	}

	public void triggerAttack(){
		animator.SetTrigger("shoot");
		audioShoot.Play();
	}

	public void triggerDead(){
		animator.SetTrigger("dead");
	}
}
