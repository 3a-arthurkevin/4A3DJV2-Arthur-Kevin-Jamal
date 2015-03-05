using UnityEngine;
using System.Collections;

public class GameHitPlayerAction : CustomActionScript
{
    [SerializeField]
    private GameHealthManager m_healthManager;

    [SerializeField]
    private int m_damage;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_healthManager.takeDamage(m_damage);

        yield return null;
    }
}
