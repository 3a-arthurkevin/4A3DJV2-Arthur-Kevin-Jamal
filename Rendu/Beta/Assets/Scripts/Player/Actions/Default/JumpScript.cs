using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour 
{
    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    [SerializeField]
    private Transform m_playerTransform;

    [SerializeField]
    private float m_distanceToJump;

    [SerializeField]
    private Vector3 m_jumpVector;

    void OnEnable()
    {
        StartCoroutine(Jump());
        enabled = false;
    }

    IEnumerator Jump()
    {
        float jumpDistance = 0f;

        m_playerAnimatorScript.LunchAction((int)PlayerAction.Jump);

        while (jumpDistance < m_distanceToJump)
        {
            jumpDistance += m_jumpVector.y;

            m_playerTransform.Translate(m_jumpVector);

            yield return null;
        }

        while (jumpDistance > 0)
        {
            jumpDistance -= m_jumpVector.y;

            m_playerTransform.Translate(-m_jumpVector);

            yield return null;
        }

        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
