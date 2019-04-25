using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrottleControl : MonoBehaviour
{

    public static Action<float> OnThrottleMoved;

    public float ThrottleValue => ThrottleSlider.value;

    [SerializeField] private Slider ThrottleSlider;

    private void Start()
    {
        if (ThrottleSlider == null) throw new NullReferenceException("ThrottleSlider is null");
        ThrottleSlider.onValueChanged.AddListener(OnThrottleMoved.Invoke);
    }
}
