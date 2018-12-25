﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//Responsavel por fazer a comunicação entre todos os outros controllers
//Toda ação deve ser passada por aqui
public class LevelController : MonoBehaviour {
	[SerializeField]
	private GUIController gui;
	[SerializeField]
	private AudioController audioController;
	[SerializeField]
	private BackgroundController bg;
	private GameObject p2;
	private P2AnimatorController p2Animator;
	private GameObject p1;
	private P1AnimatorController p1Animator;
	public KeyModel[] keys;
	public List <KeyModel> gameKeys = new List<KeyModel>();
	public Image[] player1Images;
	public Image[] player2Images;
	private float[] times = new float[2];
	public bool keysReady;
	void Start () {
		p2 = GameObject.FindGameObjectWithTag("p2");
		p2Animator = p2.GetComponent<P2AnimatorController>();
		
		p1 = GameObject.FindGameObjectWithTag("p1");
		p1Animator = p1.GetComponent<P1AnimatorController>();

		keysReady = false;
		StartCoroutine(sortKeys());
	}

	IEnumerator sortKeys(){
		for (int i = 0; i < player1Images.Length; i++)
		{
			gui.StartCursor();
			//Adicionar uma tecla aleatoria a lista de gameKeys
			gameKeys.Add(keys[UnityEngine.Random.Range(0,keys.Length)]);

			//Inserindo as imagens
			//0 - Ultima imagem //n - Primeira imagem
			player1Images[i].sprite = gameKeys[i].keySprite;
			player1Images[i].preserveAspect = true;
			player1Images[i].enabled = true;

			player2Images[i].sprite = gameKeys[i].keySprite;
			player2Images[i].preserveAspect = true;
			player2Images[i].enabled = true;

			yield return new WaitForSeconds(0.25f);
		}
		keysReady = true;
		gui.changeReadyText("GO");
	}

	public void NextKey(byte playerID, sbyte keyIndex){

		if(playerID == 0){
			player1Images[keyIndex].enabled = false;
		}else{
			player2Images[keyIndex].enabled = false;
		}
	}

	// Player 1 = 0 // Player 2 = 1
	public void SetPlayerTime(byte playerID, float time){
		times[playerID] = time;
		if(times[0] > 0 && times[1] > 0){
			if(times[0] < times[1]){
				p1Animator.triggerAttack();
				p2Animator.triggerDead();

			}else{
				p2Animator.triggerAttack();
			}
			gui.setPlayerTime(0,times[0]);
			gui.setPlayerTime(1,times[1]);			
		}
	}

	public void UpdateCursor(byte playerID){
		gui.UpdateCursor(playerID);
	}

	public void WrongPress(){
		audioController.WrongButtonPressed();
	}
}