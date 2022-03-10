using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;

    private Rigidbody _rigidbody;
    private Vector3 _velocity = Vector3.zero;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movementHorizontal = transform.right * xMovement;
        Vector3 movementVertical = transform.forward * zMovement;

        Vector3 movementVelocity = (movementHorizontal + movementVertical).normalized * _moveSpeed;

        Move(movementVelocity);
    }

    private void FixedUpdate()
    {
        if (_velocity != Vector3.zero)
        {
            _rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);
            //_rigidbody.velocity = _velocity;
        }
    }

    private void Move(Vector3 movementVelocity)
    {
        _velocity = movementVelocity;
    }
}
