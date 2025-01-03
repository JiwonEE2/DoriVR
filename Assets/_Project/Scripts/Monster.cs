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
		Move,
		Attack
	}

	private Transform _target;
	private NavMeshAgent _agent;
	private Animator _animator;
	private State _currentState = State.Move;
	public float moveSpeed = 1f;
	public float attackRange = 5f;
	public float attackCooldown = 2f;
	private float _attackTimer = 0f;

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponent<Animator>();
		_target = GameObject.Find("Main Camera").transform;
		_agent.speed = moveSpeed;
		_attackTimer = attackCooldown;
	}

	private void Update()
	{
		switch (_currentState)
		{
			case State.Move:
				Move();
				break;
			case State.Attack:
				Attack();
				break;
		}
	}

	private void Move()
	{
		if (_target == null) return;

		_animator.SetBool("isMoving", true);
		_animator.SetBool("isAttacking", false);

		// Move
		_agent.destination = _target.position;

		// Change State to Attack
		float distanceToTarget = Vector3.Distance(transform.position, _target.position);
		if (distanceToTarget < attackRange)
		{
			_currentState = State.Attack;
			_agent.isStopped = true;
		}
	}

	private void Attack()
	{
		if (_target == null) return;

		_animator.SetBool("isMoving", false);
		_animator.SetBool("isAttacking", true);

		// Check attackCooldown
		if (_attackTimer >= attackCooldown)
		{
			// Attack
			_attackTimer = 0;
			GameUI.Instance.Attacked();
		}

		float distanceToTarget = Vector3.Distance(transform.position, _target.position);
		if (distanceToTarget > attackRange)
		{
			_currentState = State.Move;
			_agent.isStopped = false;
		}
	}
}