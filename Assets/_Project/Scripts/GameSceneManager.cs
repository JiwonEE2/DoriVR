using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonManager<GameSceneManager>
{
	public bool isFirstGame = true;

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);

		Monster[] monsters = FindObjectsOfType<Monster>();
		foreach (Monster monster in monsters) Destroy(monster.gameObject);
		ScoreUI.Instance.killCount = 0;
	}
}