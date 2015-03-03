using UnityEngine;
using System.Collections;

public class GameDelegateDefinition
{
    public delegate void PlayerDisconnect();

    public delegate bool PushAction(PlayerAction action);

    public delegate bool RemoveAction(int index);

    public delegate void CommitPlayerAction();

    public delegate void LaunchSimulation();
}
