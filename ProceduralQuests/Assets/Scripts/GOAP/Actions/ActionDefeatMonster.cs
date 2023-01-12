using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDefeatMonster : GoapAction
{
    public override int GetCost()
    {
        return 1;
    }

    public override bool Execute()
    {
        int amountSword = 0;
        Blackboard.Instance.GetData("AmountSword", ref amountSword);

        int amountMonster = 0;
        Blackboard.Instance.GetData("AmountMonster", ref amountMonster);

        if (amountSword == 1 && amountMonster == 0)
        {
            WorldState.Instance.SetState("HasSword", false);
            WorldState.Instance.SetState("HasDefeatedMonster", true);
            Blackboard.Instance.ChangeData("AmountSword", 0);
            return true;
        }

        Blackboard.Instance.ChangeData("Objective", "Defeat Monster");

        return false;
    }
}
