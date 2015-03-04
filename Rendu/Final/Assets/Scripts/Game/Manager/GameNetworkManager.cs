using UnityEngine;
using System.Collections;

public class GameNetworkManager : MonoBehaviour
{
    
    public GameDelegateDefinition.PlayerDisconnect playerDisconnect;

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerDisconnect();
    }

    public int getIdPlayer(NetworkPlayer player)
    {
        int id = -1;
        int i = 1;

        foreach(NetworkPlayer p in NetworkManager.Players)
        {
            if (p == player)
            {
                id = i;
                break;
            }

            ++i;
        }

        return id;
    }
}
