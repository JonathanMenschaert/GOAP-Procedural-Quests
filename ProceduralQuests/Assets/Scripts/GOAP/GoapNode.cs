using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoapNode : MonoBehaviour
{
    private GoapAction m_Action;
    private List<GoapNode> m_Connections;

    public void Awake()
    {
        m_Connections = new List<GoapNode>();
    }

    public void AddNode(GoapNode node)
    {
        m_Connections.Add(node);
    }
}
