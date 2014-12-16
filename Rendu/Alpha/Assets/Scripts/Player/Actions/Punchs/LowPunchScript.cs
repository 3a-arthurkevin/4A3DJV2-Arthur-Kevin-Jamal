using UnityEngine;
using System.Collections;

public class LowPunchScript : MonoBehaviour 
{
    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    void OnEnable()
    {
        StartCoroutine(TakeDamage());
    }

    IEnumerator TakeDamage()
    {
        m_playerAnimatorScript.LunchAction((int)PlayerAction.LowPunch);

        yield return new WaitForSeconds(1f);

        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
