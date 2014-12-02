using UnityEngine;
using System.Collections;

public class TimerEventScript : CustomEventScript
{
    public int m_time = 1;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(m_time);

        throwEvent(this, this.gameObject);

        yield return null;
    }
}
