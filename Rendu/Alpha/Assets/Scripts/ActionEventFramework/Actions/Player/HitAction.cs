/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Action Appliquant des dégats à la cible
 * @LastModifier : Arthur TORRENTE
 */

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
