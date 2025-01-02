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

	private void Start()
	{
		StartCoroutine(SpawnMonster1Coroutine());
		StartCoroutine(SpawnMonster2Coroutine());
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
}