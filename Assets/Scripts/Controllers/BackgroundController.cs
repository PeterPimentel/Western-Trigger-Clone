using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	[SerializeField]
	private Sprite[] sprites;

	[SerializeField]
	private SpriteRenderer spRenderer;
	void Start () {
		SwapBG(Random.Range(0,sprites.Length-1));
	}
	public void SwapBG(int level){
		spRenderer.sprite = sprites[level];
	}
}
