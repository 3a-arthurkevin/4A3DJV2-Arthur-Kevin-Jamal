using UnityEngine;
using System.Collections;

public class OnTriggerEnterEvent : CustomEventScript
{
    void OnTriggerEnter(Collider col)
    {
        throwEvent(this, col.gameObject);
    }
}
