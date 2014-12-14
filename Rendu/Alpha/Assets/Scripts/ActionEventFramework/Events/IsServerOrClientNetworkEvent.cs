using UnityEngine;
using System.Collections;

public class IsServerOrClientNetworkEvent : CustomEventScript
{
    [SerializeField]
    private bool m_isServer;

    void Start()
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
