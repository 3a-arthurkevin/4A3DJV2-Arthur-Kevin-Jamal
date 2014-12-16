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
    /*
    [SerializeField]
    private PlayerManagerScript m_playerManager;
    */
    [SerializeField]
    private PlayerData m_enemyPlayerData;

    [SerializeField]
    private int m_damage;
    
    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        //Faire la verif si l'enemy a mis sa guard ici ?? ou avant ???
        //C'est pas le au niveau du gameManager que c'est gérer ? (enlever pts vie / modifier GUI health .... ) ???
        m_enemyPlayerData.Health -= m_damage;

        return null;    
    }
}
