using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InletController : BaseController
{
    [SerializeField] private float rotationForce;

    private bool activateRotors => rotorForce > 0;
    private float rotorForce;

    // Start is called before the first frame update
    private void Start()
    {
        ThrottleControl.OnThrottleMoved += UpdateRotors;
        AddEngineComponent("Inlet Helmet");
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
