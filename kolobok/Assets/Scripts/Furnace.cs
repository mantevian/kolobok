using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    [SerializeField]
    public double burnPerSecond = 0.01d;

    public double fireStrength = 0.0d;

    public double readiness = 0.0d;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        readiness += fireStrength * burnPerSecond / 60d;
    }

    public void AddWood()
    {
        fireStrength = Math.Min(1.0d, fireStrength + 0.25d);
    }
}
