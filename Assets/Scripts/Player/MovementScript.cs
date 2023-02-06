using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField] private float _movementForce = 10f;

    public Transform cam;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    float currentSpeed;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        Debug.Log("Game isn't paused!");
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }
        float speed = _movementForce * inputDir.magnitude;
        if (speed == 0)
        {
            _playerController.Idle();
        }
        else
        {
            _playerController.Move(speed);
        }
    }
}
