using UnityEngine;
using System.Collections;

public class WalkForwardScript : MonoBehaviour 
{
    [SerializeField]
    private CharacterAnimationsScript m_playerAnimatorScript;

    [SerializeField]
    private Transform m_playerTransform;

    [SerializeField]
    private float m_distanceToWalk;

    [SerializeField]
    private Vector3 m_stepVector;

    void OnEnable()
    {
        StartCoroutine(WalkForward());
    }

    IEnumerator WalkForward()
    {
        float walkDistance = 0f;

        m_playerAnimatorScript.LunchAction((int)PlayerAction.MoveForward);

        while (walkDistance < m_distanceToWalk)
        {
            walkDistance += m_stepVector.x;

            m_playerTransform.Translate(m_stepVector);

            yield return null;
        }

        m_playerAnimatorScript.LunchAction((int)PlayerAction.None);
    }
}
