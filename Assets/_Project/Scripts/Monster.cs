using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Monster : MonoBehaviour
{
	private enum State
	{
		Idle,
		Move,
		Attack
	}

	public Transform target;
	private NavMeshAgent _agent;
	private Animator _animator;
	private State currentState = State.Move;
	public float attackRange = 2f;
	public float attackCooldown = 2f;
	private float lastAttackTime = 0f;

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		switch (currentState)
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
			currentState = State.Attack;
			_agent.isStopped = true;
		}
	}

	private void Attack()
	{
		if (target == null) return;

		_animator.SetBool("isMoving", false);
		_animator.SetBool("isAttacking", true);

		// Check attackCooldown
		if (Time.time - lastAttackTime >= attackCooldown)
		{
			// Attack
			print("Monster Attacked Player!");
			lastAttackTime = Time.time;
		}

		float distanceToTarget = Vector3.Distance(transform.position, target.position);
		if (distanceToTarget > attackRange)
		{
			currentState = State.Move;
			_agent.isStopped = false;
		}
	}
}