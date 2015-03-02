/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Évènement OnTriggerEnter d'un GameObject
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class OnTriggerEnterEvent : CustomEventScript
{
    void OnTriggerEnter(Collider col)
    {
        throwEvent(this, col.gameObject);
    }
}
