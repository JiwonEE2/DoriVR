using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public float lifeTime = 5f;

	private void Start()
	{
		Destroy(gameObject, lifeTime);
	}

	private void Update()
	{
		transform.Translate(0, 0, speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		print($"Bullet: {other}Trigger Enter!");
		if (other.CompareTag("Monster"))
		{
			print("Player shot the Monster!");
			UIManager.Instance.killCount++;
			Destroy(other.gameObject);
		}

		Destroy(gameObject);
	}
}