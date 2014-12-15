using UnityEngine;
using System.Collections;

public class ApplyHighPunchDamageScript : MonoBehaviour 
{
    [SerializeField]
    private int m_highPunchDamage;

    /*
    [SerializeField]
    private PlayerStatsManager (????) m_enemyStatsManager
    */

	// Use this for initialization
	void Start () 
    {
        ApplyDamage();
	}

    public void ApplyDamage()
    {
        /*
         * m_enemyStatsManager.ApplyDamage(m_highPunchDamage); (?????)
         */
    }
}
