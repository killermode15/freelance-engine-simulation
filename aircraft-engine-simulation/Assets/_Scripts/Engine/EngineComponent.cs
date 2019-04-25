using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EngineComponent : MonoBehaviour
{
    public string Id => nameId;

    [SerializeField] private string nameId;
    private Rigidbody mRigidbody;

    private void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }
}