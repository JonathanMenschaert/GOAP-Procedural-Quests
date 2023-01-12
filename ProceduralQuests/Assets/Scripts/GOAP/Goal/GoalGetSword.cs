using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalGetSword : GoapGoal
{

    public override bool IsValid()
    {
        return !WorldState.Instance.GetState("HasSword");
    }

    public override int GetPriority()
    {
        return 1;
    }
}
