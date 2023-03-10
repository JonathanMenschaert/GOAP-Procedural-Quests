using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRetrieveSword : GoapAction
{

    public override int GetCost()
    {
        return 1;
    }

    public override bool Execute()
    {
        int amount = 0;
        Blackboard.Instance.GetData("AmountSword", ref amount);   

        if (amount > 0)
        {
            WorldState.Instance.SetState("HasSword", true);
            WorldState.Instance.SetState("SwordAvailable", false);

            return true;
        }

        Blackboard.Instance.ChangeData("Objective", "Retrieve Sword");

        return false;
    }
}
