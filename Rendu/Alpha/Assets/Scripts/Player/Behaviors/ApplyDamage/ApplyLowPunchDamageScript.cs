using UnityEngine;
using System.Collections;

public class ApplyLowPunchDamageScript : MonoBehaviour
{
    [SerializeField]
    private int m_lowPunchDamage;

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
         * m_enemyStatsManager.ApplyDamage(m_lowPunchDamage); (?????)
         */
    }
}
