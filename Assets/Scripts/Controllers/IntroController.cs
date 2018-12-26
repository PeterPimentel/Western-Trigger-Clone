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
	void Start () {
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started){
			if(Input.anyKeyDown || Input.touchCount > 0 ){
				started = true;
				start.enabled = false;
				cover.SetActive(true);
				mainMenu.SetActive(true);
			}
		}
	}
}
