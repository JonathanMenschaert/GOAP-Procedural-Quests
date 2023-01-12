using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDefeatMonster : GoapGoal
{
    // Start is called before the first frame update
    public override bool IsValid()
    {
        return !WorldState.Instance.GetState("HasDefeatedMonster");
    }

    public override int GetPriority()
    {
        return 1;
    }
}
