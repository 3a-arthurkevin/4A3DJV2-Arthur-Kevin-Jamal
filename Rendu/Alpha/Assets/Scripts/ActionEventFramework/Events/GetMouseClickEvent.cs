/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Évènement de click souris
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class GetMouseClickEvent : CustomEventScript
{
    public enum OnAction
    {
        All,
        Down,
        Up
    };

    [System.Serializable]
    public struct ScreenTouchAction
    {
        public OnAction onAction;
        public int mouseButton;
    }

    [SerializeField]
    private ScreenTouchAction[] m_mouseButtonAction;

    void Start()
    {
#if UNITY_ANDROID
        enabled = false;
#endif
    }

	void Update ()
    {
	    foreach(ScreenTouchAction mouseButton in m_mouseButtonAction)
        {
            if(mouseButton.onAction == OnAction.All)
            {
                if (Input.GetMouseButton(mouseButton.mouseButton))
                    throwEvent(this, this.gameObject);
            }
            else if(mouseButton.onAction == OnAction.Down)
            {
                if (Input.GetMouseButtonDown(mouseButton.mouseButton))
                    throwEvent(this, this.gameObject);
            }
            else if(mouseButton.onAction == OnAction.Up)
            {
                if (Input.GetMouseButtonUp(mouseButton.mouseButton))
                    throwEvent(this, this.gameObject);
            }
        }
	}
}
