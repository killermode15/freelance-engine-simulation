using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator 
{
    public static void RotateRigidbody(Rigidbody rb, float force = 3, ForceMode mode = ForceMode.Acceleration)
    {
        if (!rb) throw new NullReferenceException("Rigidbody is null");
        rb.AddTorque(rb.transform.forward * force, mode);
    }
}
