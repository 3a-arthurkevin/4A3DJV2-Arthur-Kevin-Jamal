using UnityEngine;
using System.Collections;

public class GameNetworkManager : MonoBehaviour
{
    
    public GameDelegateDefinition.PlayerDisconnect playerDisconnect;

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Application.Quit();
        Debug.Log("An client is disconnect");
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

    public NetworkPlayer getNetworkPlayer(int idPlayer)
    {
        --idPlayer;

        if(idPlayer >= 0 && idPlayer < NetworkManager.Players.Count)
        {
            return NetworkManager.Players[idPlayer];
        }

        throw new System.ArgumentException("Error in idPlayer");
    }
}
