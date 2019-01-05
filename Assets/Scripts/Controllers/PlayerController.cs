using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	public sbyte keyIndex = 8;
	public byte playerID;
	private byte opponent;
	public bool bot = true;
	private bool finished = false;
	private float time;
	private float nextKeyTime;

	private float[,] difficulty = new float[,] {
		{ 0.4f, 0.7f },
		{ 0.3f, 0.6f },
		{ 0.25f, 0.5f },
		{ 0.15f, 0.3f }
	};
	void Start () {
		bot = GameConfig.cpu;
		if(playerID == 1)
			opponent = 0;
		else opponent = 1;
	}
	void Update () {
		// Verificar se todas as teclas já foram geradas
		if(levelController.keysReady){
			if(!finished){
				time += Time.deltaTime;				
				//BOT
				if(playerID == 1 && bot){
					if(Time.time > nextKeyTime){
						nextKeyTime = Time.time + Random.Range(
							difficulty[GameConfig.difficulty,0],difficulty[GameConfig.difficulty,1]);
						KeyPress();
					}
					return;
				}

				if(Input.GetButtonDown(levelController.gameKeys[keyIndex].key[playerID])){
					KeyPress();
				}else if(Input.anyKeyDown){					
					if(!OponentMove()){
						time += 0.3f; //Punição por apertar teclas loucamente
						levelController.WrongPress();
					}
				}
			}
		}
	}

	private void KeyPress(){
		levelController.UpdateCursor(playerID);
		levelController.NextKey(playerID,keyIndex);
		keyIndex--;
		if(keyIndex < 0){
			finished = true;
			levelController.SetPlayerTime(playerID,time);
		}
	}

//Duas pessoas jogando no mesmo teclado
//Verificar se a tecla pressionada foi a do oponente
	private bool OponentMove(){
		foreach (var item in levelController.keys)
		{
			if(Input.GetButtonDown(item.key[opponent])){
				return true;
			}
		}
		return false;
	}
}
