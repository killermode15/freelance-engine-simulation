using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

public class FuelInjector : MonoBehaviour
{
    [SerializeField] private Transform fuelInjectorParent;

    [MinMaxSlider(0, 1)]
    [SerializeField] private Vector2 lifeTime;
    [MinMaxSlider(0, 30)]
    [SerializeField] private Vector2 size;

    private List<ParticleSystem> fuelInjectorFX;

    private void Awake()
    {
        ThrottleControl.OnThrottleMoved += UpdateFuelInjector;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (!fuelInjectorParent) throw new NullReferenceException("Fuel Injector Parent is null");

        fuelInjectorFX = new List<ParticleSystem>();

        foreach (Transform child in fuelInjectorParent)
        {
            ParticleSystem ps = child.GetChild(0).GetComponent<ParticleSystem>();

            if (ps != null)
            {
                fuelInjectorFX.Add(ps);
            }
        }
    }


    private void UpdateFuelInjector(float throttleAmount)
    {
        if (throttleAmount <= 0.01f)
        {
            foreach (ParticleSystem fuelInjector in fuelInjectorFX)
            {
                fuelInjector.Stop();
            }
        }

        foreach (ParticleSystem fuelInjector in fuelInjectorFX)
        {
            if(!fuelInjector.isPlaying)
                fuelInjector.Play();

            ParticleSystem.MainModule main = fuelInjector.main;
            main.startLifetime = Mathf.Lerp(lifeTime.x, lifeTime.y, throttleAmount);
            main.startSize = Mathf.Lerp(size.x, size.y, throttleAmount);
        }
    }
}
