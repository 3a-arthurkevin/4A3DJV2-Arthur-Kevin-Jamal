using UnityEngine;
using System.Collections;

public class ApplyHighKickDamageScript : MonoBehaviour 
{
    [SerializeField]
    private int m_highKickDamage;

    /*
    [SerializeField]
    private PlayerStatsManager (????) m_enemyStatsManager
    */

    // Use this for initialization
    void Start()
    {
        ApplyDamage();
    }

    public void ApplyDamage()
    {
        /*
         * m_enemyStatsManager.ApplyDamage(m_highKickDamage); (?????)
         */
    }
}
