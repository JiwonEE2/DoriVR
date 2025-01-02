using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Monster : MonoBehaviour
{
	private enum State
	{
		Idle,
		Move,
		Attack
	}

	private Transform target;
	private NavMeshAgent _agent;
	private Animator _animator;
	private State _currentState = State.Move;
	public float attackRange = 2f;
	public float attackCooldown = 2f;
	private float _lastAttackTime = 0f;

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponent<Animator>();
		target = GameObject.Find("Main Camera").transform;
	}

	private void Update()
	{
		switch (_currentState)
		{
			case State.Idle:
				Idle();
				break;
			case State.Move:
				Move();
				break;
			case State.Attack:
				Attack();
				break;
		}
	}

	private void Idle()
	{
	}

	private void Move()
	{
		if (target == null) return;

		_animator.SetBool("isMoving", true);
		_animator.SetBool("isAttacking", false);

		// Move
		_agent.destination = target.position;

		// Change State to Attack
		float distanceToTarget = Vector3.Distance(transform.position, target.position);
		if (distanceToTarget < attackRange)
		{
			_currentState = State.Attack;
			_agent.isStopped = true;
		}
	}

	private void Attack()
	{
		if (target == null) return;

		_animator.SetBool("isMoving", false);
		_animator.SetBool("isAttacking", true);

		// Check attackCooldown
		if (Time.time - _lastAttackTime >= attackCooldown)
		{
			// Attack
			_lastAttackTime = Time.time;
			SceneManager.LoadScene("TitleScene");
		}

		float distanceToTarget = Vector3.Distance(transform.position, target.position);
		if (distanceToTarget > attackRange)
		{
			_currentState = State.Move;
			_agent.isStopped = false;
		}
	}
}