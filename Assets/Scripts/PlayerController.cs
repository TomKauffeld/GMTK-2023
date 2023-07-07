using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public MySensor ForwardSensor;
    public MySensor FeetSensor;


    private void FixedUpdate()
    {
        if (ForwardSensor != null && !ForwardSensor.InContact && FeetSensor != null && FeetSensor.InContact)
            transform.Translate(speed * Time.fixedDeltaTime * Vector3.right);
    }
}
