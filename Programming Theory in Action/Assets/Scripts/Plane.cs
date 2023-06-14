using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Vehicle
{
    protected override void MoveForward()
    {
        Debug.Log("Plane Move()...");
        base.MoveForward();
        // Plane moves up when moves forward 
        forceVector = forceVector + (transform.up * Speed);
    }

    protected override void Start()
    {
        Debug.Log("Plane Start()...");
        base.Start();
    }

    protected override void Update()
    {
        Debug.Log("Plane Update()...");
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
