using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private List<GoapGoal> m_QuestList = new List<GoapGoal>();

    // Start is called before the first frame update
    public void AddQuest(GoapGoal goal)
    {
        m_QuestList.Add(goal);
    }
}
