using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : SingletonManager<ScoreUI>
{
	public int score = 0;
	public Text scoreText;

	private void Update()
	{
		scoreText.text = score.ToString();
	}
}