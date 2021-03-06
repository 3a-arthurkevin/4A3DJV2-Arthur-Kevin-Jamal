﻿using UnityEngine;
using System.Collections;

public class GameDelegateDefinition
{
    public delegate void PlayerDisconnect();

    public delegate bool PushAction(PlayerAction action);

    public delegate bool RemoveAction(int index);

    public delegate void CommitPlayerAction();

    public delegate void LaunchSimulation();

    public delegate int GetIdPlayer(NetworkPlayer player);
    public delegate NetworkPlayer GetNetworkPlayer(int idPlayer);

    public delegate void SyncActionWithServer(bool success);

    public delegate void haveTakeDamage(int playerId, int value);
}
