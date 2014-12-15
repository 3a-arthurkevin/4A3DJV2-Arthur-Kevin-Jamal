using UnityEngine;
using System.Collections;

public class ApplyLowKickDamageScript : MonoBehaviour 
{
    [SerializeField]
    private int m_lowKickDamage;

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
         * m_enemyStatsManager.ApplyDamage(m_lowKickDamage); (?????)
         */
    }
}
