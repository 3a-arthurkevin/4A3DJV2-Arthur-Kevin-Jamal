/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Évènement de touche d'écran (Mobile)
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class GetTouchScreenEvent : CustomEventScript
{
    [System.Serializable]
    public struct TouchData
    {
        public TouchPhase Phase;
        public int TouchId;
    }

    [SerializeField]
    private TouchData[] m_touch;

	public override void Start ()
    {
#if !UNITY_ANDROID
        enabled = false;
#endif
	}
	
	void Update ()
    {
        foreach(TouchData touch in m_touch)
            if (Input.touchCount > 0 &&  Input.GetTouch(touch.TouchId).phase == touch.Phase)
                throwEvent(this, this.gameObject);
	}
}
