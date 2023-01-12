using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMakeSword : GoapAction
{
    public override int GetCost()
    {
        return 2;
    }

    public override bool Execute()
    {
        int amount = 0;
        Blackboard.Instance.GetData("AmountSword", ref amount);
        //Blackboard.Instance.ChangeData("Objective", "Retrieve Sword");

        if (amount > 1)
        {
            WorldState.Instance.SetState("HasSword", true);
            return true;
        }
        return false;
    }
}
