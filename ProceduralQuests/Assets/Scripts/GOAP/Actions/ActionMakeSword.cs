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
        Blackboard.Instance.GetData("AmountMaterial", ref amount);

        if (amount > 0)
        {
            WorldState.Instance.SetState("SwordAvailable", true);
            return true;
        }
        return false;
    }
}
