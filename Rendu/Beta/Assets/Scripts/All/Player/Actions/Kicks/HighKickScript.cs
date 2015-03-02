using UnityEngine;
using System.Collections;

public class HighKickScript : MonoBehaviour 
{
    [SerializeField]
    private OnTriggerEnterEvent m_playerFootTriggerEvent;

    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    void OnEnable()
    {
        StartCoroutine(TakeDamage());
        enabled = false;
    }

    IEnumerator TakeDamage()
    {
        m_playerFootTriggerEvent.enabled = true;
        m_playerAnimatorScript.LunchAction((int)PlayerAction.HighKick);

        yield return new WaitForSeconds(1f);

        m_playerFootTriggerEvent.enabled = false;
        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
