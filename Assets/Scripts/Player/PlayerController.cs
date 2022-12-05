using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    internal Animator animator;

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        //var mousePos = Input.mousePosition;
        //mousePos.y = Screen.width / 2;
        //mousePos.x = Screen.height * 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Acorn"))
        {
            Collectable.Instance.quantity++;
            Destroy(collision.gameObject);
        }
    }

    public void Idle()
    {
        animator.SetFloat("State", 0);
    }

    public void Move(float speed)
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        animator.SetFloat("State", 1);
    }
}
