using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AnimatorController : MonoBehaviour {
	private Animator animator;
	[SerializeField]
	private AudioSource audioShoot;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void triggerAttack(){
		animator.SetTrigger("shoot");
		audioShoot.Play();		
	}

	public void triggerDead(){
		animator.SetTrigger("dead");
	}
}
