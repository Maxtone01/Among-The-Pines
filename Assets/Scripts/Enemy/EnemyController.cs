using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool startPlayerChase;
    private Patroling _patroling;
    private GameManager _gameManager;
    void Start()
    {
        startPlayerChase = false;
        _patroling = GetComponent<Patroling>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Collectable.Instance.quantity == 4)
        //{ 
        //    startPlayerChase = true;
        //}
        //if (Collectable.Instance.quantity == 5)
        //{
        //    startPlayerChase = false;
        //    ResetPath();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "The Beaver")
        {
            Debug.Log("Game over");
            Destroy(other.gameObject);
            _gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            _gameManager.StartGame();
        }
    }


    private void ResetPath()
    {
        _patroling.agent.isStopped = true;
        _patroling.agent.ResetPath();
    }
}
