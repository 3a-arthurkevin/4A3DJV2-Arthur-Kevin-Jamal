/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Classe abstraite des évènements
 */

using UnityEngine;
using System.Collections;

/**
 * Each event inheriting CustomEventScript called throwEvent function to call all the Action subscribed to the event.
 */
public abstract class CustomEventScript : MonoBehaviour
{
    /**
     * Delegate used for stored Action function was called each Event was throw
     */
    public delegate void CustomEventDelegate(MonoBehaviour eventSender, GameObject args);

    [SerializeField]
    public CustomEventDelegate m_functionsWasCalled;

    /**
     * Call all subscriber Action with inherit event throw event
     */
    public void throwEvent(MonoBehaviour eventSender, GameObject args)
    {
        if (m_functionsWasCalled != null)
            m_functionsWasCalled(eventSender, args);
    }
}
