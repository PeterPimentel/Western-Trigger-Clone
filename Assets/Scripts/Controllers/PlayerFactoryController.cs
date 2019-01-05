using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactoryController : MonoBehaviour {

	[SerializeField]
	private GameObject[] charactersPlayer;

	[SerializeField]
	private Transform[] spawPoints;

	public GameObject GetCharacter1(byte id){
		GameObject character = Instantiate(charactersPlayer[id],spawPoints[0]);
		character.SetActive(true);
		return character;
	}

	public GameObject GetCharacter2(byte id){
		GameObject character = Instantiate(charactersPlayer[id],spawPoints[1]);
		var scaleX = character.transform.localScale.x;
		var scaleY = character.transform.localScale.y;
		character.transform.localScale = new Vector3(scaleX*-1,scaleY,1);
		character.SetActive(true);
		return character;
	}
}
