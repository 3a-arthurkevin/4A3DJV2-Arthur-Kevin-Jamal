/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Active un Game Object
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class EnableGameObjectAction : CustomActionScript
{
    [SerializeField]
    private GameObject m_gameObject;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_gameObject.SetActive(true);

        yield return null;
    }
}
