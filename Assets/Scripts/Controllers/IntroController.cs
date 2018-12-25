using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

	private bool started;
	[SerializeField]
	private GameObject cover;

	[SerializeField]
	private TextMeshProUGUI start;

	[SerializeField]
	private GameObject mainMenu;

	private TextUtil textUtil;
	void Start () {
		started = false;
		textUtil = new TextUtil();
	}
	
	// Update is called once per frame
	void Update () {
		if(!started){
			if(Input.anyKeyDown || Input.touchCount > 0 ){
				started = true;
				StartCoroutine(textUtil.FadingOut(start));
				cover.SetActive(true);
				mainMenu.SetActive(true);
			}
		}
	}
}
