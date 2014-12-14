/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Active un Game Object
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class SetActiveScriptAction : CustomActionScript
{
    [SerializeField]
    private GameObject[] m_gameObject;

    [SerializeField]
    private bool m_active;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        foreach(GameObject go in m_gameObject)
            go.SetActive(m_active);

        yield return null;
    }
}
