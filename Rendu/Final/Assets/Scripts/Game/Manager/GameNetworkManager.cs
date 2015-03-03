using UnityEngine;
using System.Collections;

public class GameNetworkManager : MonoBehaviour
{
    
    public GameDelegateDefinition.PlayerDisconnect playerDisconnect;

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerDisconnect();
    }
}
