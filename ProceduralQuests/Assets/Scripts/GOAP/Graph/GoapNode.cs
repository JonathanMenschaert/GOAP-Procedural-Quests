using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoapNode
{
    private GoapAction m_Action = null;
    private List<GoapNode> m_Connections;

    public GoapNode(GoapAction action)
    {
        m_Action = action;
        m_Connections = new List<GoapNode>();
    }

    public void AddNode(GoapNode node)
    {
        m_Connections.Add(node);
    }

    public int Length()
    {
        return m_Connections.Count;
    }

    public GoapAction GetAction()
    {
        return m_Action;
    }
}
