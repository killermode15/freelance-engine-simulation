using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompressorRotorController : BaseController
{
    [SerializeField] private float rotationForce;

    private bool activateRotors => rotorForce > 0;
    private float rotorForce;

    // Start is called before the first frame update
    private void Start()
    {
        ThrottleControl.OnThrottleMoved += UpdateRotors;
        GetEngineComponents("Compressor Rotor");
    }

    // Update is called once per frame
    private void Update()
    {
        if (!activateRotors) return;

        foreach (EngineComponent rotor in components)
        {
            Rigidbody rb = rotor.GetComponent<Rigidbody>();
            Rotator.RotateRigidbody(rb, rotorForce);
        }
    }

    private void UpdateRotors(float throttleValue)
    {
        if (throttleValue <= 0) return;

        rotorForce = throttleValue * rotationForce;
    }

    

}
