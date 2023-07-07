using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTarget : MonoBehaviour
{
    public Action<PlayerController> OnPlayerHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController controller))
            OnPlayerHit?.Invoke(controller);
    }
}
