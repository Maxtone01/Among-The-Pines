using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroling : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    private Animator _animator;
    public LayerMask _playerMask;

    [SerializeField]
    private float viewRadius;

    private EnemyController _enemyController;

    public Transform _player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        _animator = GetComponent<Animator>();
        _enemyController = GetComponent<EnemyController>();

        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        Debug.Log("patroling");
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPLayer();
        if (_enemyController.startPlayerChase)
        {
            ChasePlayer();
        }
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        _animator.SetFloat("State", 1);
        CheckPLayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(_player.position);
    }

    private void CheckPLayer()
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, viewRadius, _playerMask);
        if (collision.Length >= 1)
        {
            ChasePlayer();
        }
        else
        {
            //agent.isStopped = true;
            //agent.ResetPath();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
