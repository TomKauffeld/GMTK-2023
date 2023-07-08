using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class MySensor : MonoBehaviour
{
    public event Action OnContact;

    private const float GC_TIME = 0.5f;
    private float untilNextClean = GC_TIME;

    public int hits;
    public int Hits => Contacts.Count;
    public bool InContact => Hits > 0;

    private readonly List<Collider> Contacts = new();


    private void Update()
    {
        hits = Hits;
        untilNextClean -= Time.deltaTime;
        if (untilNextClean <= 0)
        {
            for (int i = Contacts.Count - 1; i >= 0; --i)
                if (Contacts[i].IsUnityNull() || Contacts[i].IsDestroyed())
                    Contacts.RemoveAt(i);
            untilNextClean += GC_TIME;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && !Contacts.Contains(other))
        {
            bool inContact = InContact;
            Contacts.Add(other);
            if (!inContact)
                OnContact?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Contacts.Remove(other);
    }


}
