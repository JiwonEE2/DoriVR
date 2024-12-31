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

	private void Awake()
	{
		ABC = GetComponentInParent<ActionBasedController>();
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
		if (context.performed)
		{
			Instantiate(bulletPrefab, startBulletPos.position, startBulletPos.rotation);
		}
	}
}