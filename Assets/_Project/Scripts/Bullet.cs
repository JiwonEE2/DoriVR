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
		if (other.CompareTag("Monster"))
		{
			GameUI.Instance.score++;
			Destroy(other.gameObject);
		}

		Destroy(gameObject);
	}
}