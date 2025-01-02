using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : SingletonManager<ScoreUI>
{
	public int killCount = 0;

	public Text killCountText;

	private void Update()
	{
		killCountText.text = killCount.ToString();
	}
}