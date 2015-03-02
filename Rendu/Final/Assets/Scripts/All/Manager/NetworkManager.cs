using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NetworkManager : MonoBehaviour
{
    private static List<NetworkPlayer> m_players = new List<NetworkPlayer>();
    public static List<NetworkPlayer> Players
    {
        get { return NetworkManager.m_players; }
    }

    public static void addPlayer(NetworkPlayer player)
    {
        m_players.Add(player);
    }

    public static bool removePlayer(NetworkPlayer player)
    {
        return m_players.Remove(player);
    }
}
