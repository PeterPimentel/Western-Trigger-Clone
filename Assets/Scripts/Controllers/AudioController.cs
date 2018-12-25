using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	[SerializeField]
	private AudioSource wrongButton;
	
	// Use this for initialization
	void Start () {
		
	}
	public void WrongButtonPressed(){
		wrongButton.Play();
	}
}
