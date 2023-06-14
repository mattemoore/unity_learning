using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Car : Vehicle
{
    //POLYMORPHISM
    protected override void MoveForward()
    {
        // Car class can't move up
        Debug.Log("Car Move()...");
        base.MoveForward();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        Debug.Log("Car Start()...");
        base.Start();
    }

    protected override void Update()
    {
        Debug.Log("Car Update()...");
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
