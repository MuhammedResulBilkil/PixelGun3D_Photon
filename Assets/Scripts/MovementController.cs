using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _lookSensitivity = 3f;
    [SerializeField] private Camera _fpsCamera;

    private Rigidbody _rigidbody;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private float _cameraUpAndDownRotation = 0f;
    private float _currentCameraUpAndDownRotation = 0f;
    

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

        float yRotation = Input.GetAxis("Mouse X");
        Vector3 rotationVector = new Vector3(0f, yRotation, 0f) * _lookSensitivity;

        Rotate(rotationVector);

        float cameraUpAndDownRotation = Input.GetAxis("Mouse Y");

        RotateCamera(cameraUpAndDownRotation);
    }

    private void RotateCamera(float cameraUpAndDownRotation)
    {
        _cameraUpAndDownRotation = cameraUpAndDownRotation;
    }

    private void Rotate(Vector3 rotationVector)
    {
        _rotation = rotationVector;
    }

    private void FixedUpdate()
    {
        if (_velocity != Vector3.zero)
        {
            _rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);
        }
        
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(_rotation));
    }

    private void LateUpdate()
    {
        if (_fpsCamera != null)
        {
            _currentCameraUpAndDownRotation -= _cameraUpAndDownRotation;
            _currentCameraUpAndDownRotation = Mathf.Clamp(_currentCameraUpAndDownRotation, -85f, 85f);

            _fpsCamera.transform.localEulerAngles = new Vector3(_currentCameraUpAndDownRotation, 0f, 0f);
        }
    }

    private void Move(Vector3 movementVelocity)
    {
        _velocity = movementVelocity;
    }
}
