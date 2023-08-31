using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    protected Vector3 forceVector;
    protected Rigidbody rigidBody;

    private float _forceTimer;
    [SerializeField]
    protected float forceTime;

    //ENCAPSULATION
    [SerializeField]
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set
        {
            if (value >= 0)
            {

                _speed = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cannot set Speed property of Vehicle to a negative integer.");
            }
        }
    }

    protected virtual void MoveForward()
    {
        _forceTimer = forceTime;
        forceVector = transform.forward * Speed;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Debug.Log("Vehicle Start()...");
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log("Vehicle Update()...");
        if (Input.GetAxis("Vertical") > 0 && _forceTimer <= 0)
        {
            MoveForward();
        }
    }

    protected virtual void FixedUpdate()
    {
        Debug.Log("Vehicle FixedUpdate()...");
        Debug.Log("_forceTimer:" + _forceTimer);
        if (_forceTimer > 0)
        {
            Debug.Log("Applying relative force w/ vector:" + forceVector);
            rigidBody.AddRelativeForce(forceVector, ForceMode.Impulse);
            _forceTimer -= Time.fixedDeltaTime;
        }
    }
}
