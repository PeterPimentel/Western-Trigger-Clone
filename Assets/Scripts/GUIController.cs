using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GUIController : MonoBehaviour {
	[SerializeField]
	private TextMeshProUGUI[] timeTexts;
	[SerializeField]
	private TextMeshProUGUI readyText;

	[SerializeField]
	private RectTransform[] cursor;

	private const int cursorMovemente = 110;
	void Start () {
		
	}
	public void setPlayerTime(byte playerID, float time){
		timeTexts[playerID].text = time.ToString("0.00") + "s";
	}

	private IEnumerator FadingText(TextMeshProUGUI text){
		Color newColor = text.color;
		while(newColor.a > 0){
			newColor.a -= Time.deltaTime;
			text.color = newColor;
			yield return null;
		}
	}

	public void changeReadyText(string msg){
		readyText.text = msg;
		StartCoroutine(FadingText(readyText));
	}

	public void UpdateCursor(byte playerID){
		cursor[playerID].anchoredPosition = new Vector2(cursor[playerID].anchoredPosition.x,cursor[playerID].anchoredPosition.y - cursorMovemente);
	}
	public void StartCursor(){
		foreach (var item in cursor)
		{
			item.anchoredPosition = new Vector2(item.anchoredPosition.x,item.anchoredPosition.y + cursorMovemente);	
		}		
	}

	public void ReloadScene(){
		SceneManager.LoadScene("game");
	}
}
