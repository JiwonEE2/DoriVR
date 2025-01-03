using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
	private ActionBasedController ABC;
	public GameObject bulletPrefab;
	public Transform startBulletPos;

	public float shotInterval = 1f;
	private float shotTimer;

	private void Awake()
	{
		ABC = GetComponentInParent<ActionBasedController>();
	}

	private void Update()
	{
		shotTimer += Time.deltaTime;
	}

	private void OnEnable()
	{
		ABC.selectAction.reference.action.performed += TriggerAction;
		ABC.selectAction.reference.action.canceled += TriggerAction;
	}

	private void OnDisable()
	{
		ABC.selectAction.reference.action.performed -= TriggerAction;
		ABC.selectAction.reference.action.canceled -= TriggerAction;
	}

	private void TriggerAction(InputAction.CallbackContext context)
	{
		if (context.performed && shotTimer >= shotInterval)
		{
			Instantiate(bulletPrefab, startBulletPos.position, startBulletPos.rotation);
			shotTimer = 0;
		}
	}
}