using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile _currentPile = null;
    public int ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if (_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;
            if (pile != null)
            {
                _currentPile = pile;
                _currentPile.ProductionSpeed += ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (_currentPile != null)
        {
            _currentPile.ProductionSpeed -= ProductivityMultiplier;
            _currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target); // run method from base class
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
