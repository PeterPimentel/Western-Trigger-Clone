using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUtil {
	public IEnumerator FadingOut(TextMeshProUGUI text){
		Color newColor = text.color;
		while(newColor.a > 0){
			newColor.a -= Time.deltaTime;
			text.color = newColor;
			yield return null;
		}
	}

	public IEnumerator FadingIn(TextMeshProUGUI text){
		Color newColor = text.color;
		while(newColor.a < 255){
			newColor.a += Time.deltaTime;
			text.color = newColor;
			yield return null;
		}
	}
}
