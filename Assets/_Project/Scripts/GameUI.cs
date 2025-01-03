using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : SingletonManager<GameUI>
{
	public int score = 0;
	public Text scoreText;

	public int heartCount = 5;
	public GameObject heartSlot;
	public GameObject heartPrefab;
	private List<GameObject> hearts;

	public Sprite fullHeartSprite;
	public Sprite emptyHeartSprite;

	private int _curHeartCount;

	public ParticleSystem particle;

	private void Start()
	{
		_curHeartCount = heartCount;

		hearts = new List<GameObject>(_curHeartCount);
		for (int i = 0; i < _curHeartCount; i++)
		{
			hearts.Add(Instantiate(heartPrefab, heartSlot.transform));
			hearts[i].GetComponent<Image>().sprite = fullHeartSprite;
		}
	}

	private void Update()
	{
		scoreText.text = score.ToString();
	}

	public void Attacked()
	{
		_curHeartCount--;
		particle.gameObject.SetActive(true);
		particle.Play();
		DieCheck();
		hearts[_curHeartCount].GetComponent<Image>().sprite = emptyHeartSprite;
	}

	private void DieCheck()
	{
		if (_curHeartCount <= 0)
		{
			SceneManager.LoadScene("TitleScene");
		}
	}
}