using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour 
{
    [SerializeField]
    private Transform m_playerTransform;

    [SerializeField]
    private float m_distanceToJump;

    [SerializeField]
    private Vector3 m_jumpVector;

    void Start()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        float jumpDistance = 0f;
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
    }
}
