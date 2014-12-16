using UnityEngine;
using System.Collections;

public class WalkForwardScript : MonoBehaviour 
{
    [SerializeField]
    private Transform m_playerTransform;

    [SerializeField]
    private float m_distanceToWalk;

    [SerializeField]
    private Vector3 m_stepVector;

    void Start()
    {
        StartCoroutine(WalkForward());
    }

    IEnumerator WalkForward()
    {
        float walkDistance = 0f;
        while (walkDistance < m_distanceToWalk)
        {
            walkDistance += m_stepVector.x;

            m_playerTransform.localPosition += m_stepVector;

            yield return null;
        }
    }
}
