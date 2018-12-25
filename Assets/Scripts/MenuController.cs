using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public void StartGame(bool cpu){
		SceneManager.LoadScene("Selects");
		GameConfig.cpu = cpu;
	}

	public void SelectStage(int stage){
		SceneManager.LoadScene("Game");
		GameConfig.stage = (byte)stage;
	}
}
