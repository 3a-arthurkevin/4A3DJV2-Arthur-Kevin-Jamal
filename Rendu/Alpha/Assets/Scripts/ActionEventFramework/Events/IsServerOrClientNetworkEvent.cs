/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Évènement de détection IsServer/IsClient
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class IsServerOrClientNetworkEvent : CustomEventScript
{
    [SerializeField]
    private bool m_isServer;

    public override void Start()
    {
        if (m_isServer)
        {
            if (Network.isServer)
                throwEvent(this, gameObject);
        }
        else
        {
            if (Network.isClient)
                throwEvent(this, gameObject);
        }
    }
}
