using UnityEngine;
using System.Collections;

public class TakeDamageScript : MonoBehaviour 
{
    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    void OnEnable()
    {
        StartCoroutine(TakeDamage());
        enabled = false;
    }

    IEnumerator TakeDamage()
    {
        m_playerAnimatorScript.LunchAction((int)PlayerAction.TakeDamage);

        yield return new WaitForSeconds(1f);

        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
