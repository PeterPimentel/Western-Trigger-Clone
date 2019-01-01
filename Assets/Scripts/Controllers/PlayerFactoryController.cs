using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactoryController : MonoBehaviour {

	[SerializeField]
	private GameObject[] charactersPlayer2;
	private GameObject[] charactersPlayer1;
	public GameObject GetCharacter2(byte id){
		GameObject character = charactersPlayer2[id];
		character.SetActive(true);
		return character;
	}

	public GameObject GetCharacter1(byte id){
		GameObject character = charactersPlayer1[id];
		character.SetActive(true);
		return character;
	}
}
