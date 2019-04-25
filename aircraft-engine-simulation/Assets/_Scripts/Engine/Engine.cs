using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public List<string> rotorIds;
    [SerializeField] private List<string> components;

    // Start is called before the first frame update
    private void Awake()
    {
        components = EngineComponentManager.GetIds();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UpdateRotors();
            EngineComponent inletHelmet = EngineComponentManager.Get("Inlet Helmet");
            RotateRigidbody(inletHelmet.GetComponent<Rigidbody>());
        }
    }

    private void UpdateRotors()
    {
        rotorIds = components.Where(x => x.Contains("Compressor Rotor".ToLower())).ToList();

        foreach (string rotorId in rotorIds)
        {
            EngineComponent rotor = EngineComponentManager.Get(rotorId);
            RotateRigidbody(rotor.GetComponent<Rigidbody>());
        }
    }

    private void RotateRigidbody(Rigidbody rb, float force = 3, ForceMode mode = ForceMode.Force)
    {

        rb.AddTorque(rb.transform.forward * force, mode);
    }
}
