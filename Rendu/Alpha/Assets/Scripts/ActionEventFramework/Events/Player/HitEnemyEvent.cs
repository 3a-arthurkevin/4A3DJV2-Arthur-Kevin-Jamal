using UnityEngine;
using System.Collections;

public class HitEnemyEvent : CustomEventScript 
{
    void OnTriggerEnter(Collider col)
    {
        throwEvent(this, col.gameObject);
    }
}
