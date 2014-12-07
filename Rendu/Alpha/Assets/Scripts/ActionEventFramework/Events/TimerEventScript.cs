/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Évènement de temp
 */

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
