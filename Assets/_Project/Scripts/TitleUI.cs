using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
	public Text welcomeText;
	public Text dieText;
	public Text scoreText;
	public Button startButton;
	public Button quitButton;

	private void Awake()
	{
		startButton.onClick.AddListener(StartButtonClick);
		quitButton.onClick.AddListener(QuitButtonClick);
	}

	private void OnEnable()
	{
		if (GameSceneManager.Instance.isFirstGame)
		{
			welcomeText.gameObject.SetActive(true);
			dieText.gameObject.SetActive(false);
			scoreText.gameObject.SetActive(false);
		}
		else
		{
			welcomeText.gameObject.SetActive(false);
			dieText.gameObject.SetActive(true);
			scoreText.text = $"Score : {ScoreUI.Instance.killCount}";
			scoreText.gameObject.SetActive(true);
		}
	}

	private void StartButtonClick()
	{
		GameSceneManager.Instance.isFirstGame = false;
		SceneManager.LoadScene("GameScene");
	}

	private void QuitButtonClick()
	{
		Application.Quit();
	}
}