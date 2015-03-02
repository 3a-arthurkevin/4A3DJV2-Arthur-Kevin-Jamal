/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Classe abstraite des actions
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public abstract class CustomActionScript : MonoBehaviour
{
    public enum RegisterTime
    {
        OnStart,
        OnAwake
    };

    /**
     * List of event was subscribes
     */
    public CustomEventScript[] m_events;

    /**
     * Max number of Action launched
     */
    public int m_maxTriggerCount = int.MaxValue;

    /**
     * Number of action launched
     */
    public int m_triggeredCount = 0;

    /**
     * Timer between throwEvent and start Action
     */
    public int m_delay = 0;

    /**
     * Delay between 2 action
     */
    public int m_delayBetweenTrigger = 0;

    /**
     * Disable multi Action at the same time
     */
    public bool m_oneAtTime = false;

    /**
     * Repeat Action
     */
    public bool m_repeated = false;

    /**
     * Repeat Action already m_repeatCount > 0
     */
    public bool m_repeatCountsBounded = false;

    /**
     * Number of repeat execution Action
     */
    public int m_repeatCount = 0;

    /**
     * Value of current number of execution repeated
     */
    protected int m_repeatStartCount = 0;

    /**
     * Repeat Action at Time
     */
    public bool m_repeatTimeBounded = false;

    /**
     * Time to repeat
     */
    public int m_repeatTime = 0;

    /**
     * Current time of execution
     */
    private float m_repeatStartTime = 0.0f;

    /**
     * When Action subscribe at events
     */
    public RegisterTime m_registerTime = RegisterTime.OnStart;

    /**
     * Register at all events
     */
    public void RegisterAtAll()
    {
        if(m_events != null)
            foreach (CustomEventScript event_ in m_events)
                if(event_ != null)
                    event_.m_functionsWasCalled += DoAction;
    }

    /**
     * Unregister at all events
     */
    public void UnregisterAtAll()
    {
        if (m_events != null)
            foreach (CustomEventScript event_ in m_events)
                if (event_ != null)
                    event_.m_functionsWasCalled -= DoAction;
    }

    /**
     * Draw Debug line for each connection with event
     */
    public virtual void OnDrawGizmos()
    {
        if(m_events != null && m_events.Length > 0)
            foreach (CustomEventScript evt in m_events)
                Debug.DrawLine(evt.transform.position, this.transform.position, Color.green);
    }

    /** 
     * Just use for RegisterTime
     */
    public virtual void Start()
    {
        if (m_registerTime == RegisterTime.OnStart)
            RegisterAtAll();
    }

    /** 
     * Just use for RegisterTime
     */
    public virtual void Awake()
    {
        if (m_registerTime == RegisterTime.OnAwake)
            RegisterAtAll();
    }

    /** 
     * Just use for UnregisterTime
     */
    public virtual void OnDestroy()
    {
        StopAllCoroutines();
        UnregisterAtAll();
    }


    public virtual void DoAction(MonoBehaviour eventSender, GameObject args)
    {
        if (m_oneAtTime)
            StopAllCoroutines();

        if(this.gameObject.activeInHierarchy)
        {
            StartCoroutine(DoActionCorotine(eventSender, args));

            ++m_triggeredCount;
            
            if(m_triggeredCount >= m_maxTriggerCount)
                UnregisterAtAll();
        }
    }

    public virtual IEnumerator DoActionCorotine(MonoBehaviour eventSender, GameObject args)
    {
        if (m_delay > 0)
            yield return new WaitForSeconds(m_delay);

        m_repeatStartTime = Time.time;
        m_repeatStartCount = m_repeatCount;

        do
        {
            yield return StartCoroutine(DoActionOnEvent(eventSender, args));

            if(m_delayBetweenTrigger > 0)
                yield return new WaitForSeconds(m_delayBetweenTrigger);

        }while(m_repeated && (!m_repeatCountsBounded || --m_repeatStartCount > 0) && (!m_repeatTimeBounded || Time.time - m_repeatStartTime <= m_repeatTime));

        yield return null;
    }

    protected abstract IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args);
}
