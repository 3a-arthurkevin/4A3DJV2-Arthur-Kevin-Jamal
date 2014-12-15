/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Évènement de temp
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class TimerEvent : CustomEventScript
{
    public int m_time = 1;

    public new IEnumerator Start()
    {
        yield return new WaitForSeconds(m_time);

        throwEvent(this, this.gameObject);

        yield return null;
    }
}
