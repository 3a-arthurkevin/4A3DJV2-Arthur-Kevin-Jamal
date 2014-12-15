using UnityEngine;
using System.Collections;

public class HitAction : CustomActionScript
{
    //TODO Replace By StatManagerPlayer or other
    [SerializeField]
    private PlayerManagerScript m_playerManager;
    
    [SerializeField]
    private int m_damage;
    
    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        return null;    
    }
}
