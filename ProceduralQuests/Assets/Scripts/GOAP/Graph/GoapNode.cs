using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoapNode
{
    private GoapAction m_Action;
    private List<GoapNode> m_Connections;

    public GoapNode()
    {
        m_Connections = new List<GoapNode>();
    }

    public void AddNode(GoapNode node)
    {
        m_Connections.Add(node);
    }
}
