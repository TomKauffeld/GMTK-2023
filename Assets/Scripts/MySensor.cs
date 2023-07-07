using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class MySensor : MonoBehaviour
{
    public int hits;
    public int Hits { get; private set; }
    public bool InContact => Hits > 0;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            ++hits;
            ++Hits;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            --hits;
            --Hits;
        }
    }


}
