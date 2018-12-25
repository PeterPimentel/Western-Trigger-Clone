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
	void Start () {
		if(playerID == 1)
			opponent = 0;
		else opponent = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// Verificar se todas as teclas já foram geradas
		if(levelController.keysReady){
			if(!finished){
				time += Time.deltaTime;
				
				//BOT
				if(playerID == 1 && bot){
					if(Time.time > nextKeyTime){
						// nextKeyTime = Time.time + Random.Range(0.25f,0.5f);
						nextKeyTime = Time.time + Random.Range(0.4f,0.8f);
						KeyPress();
					}
					return;
				}

				if(Input.GetButtonDown(levelController.gameKeys[keyIndex].key[playerID])){
					KeyPress();
				}else if(Input.anyKeyDown){
					time += 0.3f; //Punição por apertar teclas loucamente
					levelController.WrongPress();
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
}
