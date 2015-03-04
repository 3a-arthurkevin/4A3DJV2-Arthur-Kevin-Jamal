using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameUtils
{
    public static string PlayerActionsArrayToString(PlayerAction[] actions)
    {
        string actionsString = "";

        foreach(PlayerAction action in actions)
        {
            actionsString += (int)action + ";";
        }

        return actionsString;
    }

    public static PlayerAction[] PlayerActionsStringToArray(string actionsString)
    {
        List<PlayerAction> actionsList = new List<PlayerAction>();

        string[] listAction = actionsString.Split( new char[] {';'} );

        for (int i = 0; i < listAction.Length - 1; ++i)
        {
            try
            {
                actionsList.Add((PlayerAction)System.Int32.Parse(listAction[i]));
            }
            catch (System.Exception)
            {
                Debug.LogError("string have an error");
            }
        }

        return actionsList.ToArray();
    }
}
