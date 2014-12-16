using UnityEngine;
using System.Collections;

public class GuardScript : MonoBehaviour 
{
    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    void OnEnable()
    {
        StartCoroutine(Guard());
        enabled = false;
    }

    IEnumerator Guard()
    {
        m_playerAnimatorScript.LunchAction((int)PlayerAction.Guard);

        yield return new WaitForSeconds(1f);

        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
