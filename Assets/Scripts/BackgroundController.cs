using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	[SerializeField]
	private Sprite[] sprites;

	[SerializeField]
	private SpriteRenderer spRenderer;
	void Start () {
		SwapBG(GameConfig.stage);
	}
	public void SwapBG(byte level){
		spRenderer.sprite = sprites[level];
	}
}
