using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public void GoToSelects(bool cpu){
		SceneManager.LoadScene("Selects");
		GameConfig.cpu = cpu;
	}

	public void SetDifficulty(int diff){
		SceneManager.LoadScene("Selects");
		GameConfig.cpu = true;
		GameConfig.difficulty = (byte)diff;
	}

	public void SelectCharacter1(int id){
		GameConfig.character1 = (byte)id;
	}

	public void SelectCharacter2(int id){
		GameConfig.character2 = (byte)id;
		SceneManager.LoadScene("Game");
	}
}
