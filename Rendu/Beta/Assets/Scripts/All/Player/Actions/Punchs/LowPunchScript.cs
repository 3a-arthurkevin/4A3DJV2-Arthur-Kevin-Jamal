using UnityEngine;
using System.Collections;

public class LowPunchScript : MonoBehaviour 
{
    [SerializeField]
    private OnTriggerEnterEvent m_playerFistTriggerEvent;

    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    void OnEnable()
    {
        StartCoroutine(TakeDamage());
        enabled = false;
    }

    IEnumerator TakeDamage()
    {
        m_playerFistTriggerEvent.enabled = true;
        m_playerAnimatorScript.LunchAction((int)PlayerAction.LowPunch);

        yield return new WaitForSeconds(1f);

        m_playerFistTriggerEvent.enabled = false;
        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
