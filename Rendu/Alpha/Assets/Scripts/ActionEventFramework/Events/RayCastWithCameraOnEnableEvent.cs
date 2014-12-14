/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Lance un RayCast  depuis l'écran lorsque que le script est activé
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class RayCastWithCameraOnEnableEvent : CustomEventScript
{
    [SerializeField]
    private Camera m_camera;
    public Camera CameraForRay
    {
        set { m_camera = value; }
    }

    [SerializeField]
    private int m_touchId;

    [SerializeField]
    private LayerMask m_layer;
	
    void OnEnable()
    {
#if UNITY_ANDROID
        Vector3 ori = new Vector3(Input.GetTouch(m_touchId).position.x, Input.GetTouch(m_touchId).position.y, m_camera.nearClipPlane);
#else
        Vector3 ori = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_camera.nearClipPlane);
#endif
        Ray ray = m_camera.ScreenPointToRay(ori);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, m_layer.value))
            throwEvent(this, hit.collider.gameObject);
        else
            Debug.Log("Ray failed");
        
        enabled = false;
    }
}
