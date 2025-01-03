using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	public GameObject monster1Prefab;
	public GameObject monster2Prefab;

	public float monster1SpawnRate = 3f;
	public float monster2SpawnRate = 10f;

	public float spawnRateUpTime = 5f;
	private float _timer;

	private void Start()
	{
		StartCoroutine(SpawnMonster1Coroutine());
		StartCoroutine(SpawnMonster2Coroutine());
		_timer = spawnRateUpTime;
	}

	private void Update()
	{
		if (monster1SpawnRate >= 0.4f)
		{
			_timer += Time.deltaTime;
			SpawnRateDown();
		}
	}

	private IEnumerator SpawnMonster1Coroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(monster1SpawnRate);
			SpawnMonster(monster1Prefab);
		}
	}

	private IEnumerator SpawnMonster2Coroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(monster2SpawnRate);
			SpawnMonster(monster2Prefab);
		}
	}

	private void SpawnMonster(GameObject monsterPrefab)
	{
		GameObject monster = Instantiate(monsterPrefab, transform);
	}

	private void SpawnRateDown()
	{
		if (_timer >= spawnRateUpTime)
		{
			monster1SpawnRate /= 2;
			monster2SpawnRate /= 2;
			_timer = 0;
		}
	}
}