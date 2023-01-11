using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapState : MonoBehaviour
{
    [SerializeField]
    private string m_State;

    [SerializeField]
    private bool m_Value;
    // Start is called before the first frame update

    public void OnEnable()
    {
        GoapPlanner.Instance.RegisterState(m_State, m_Value);
    }

    public void OnDisable()
    {
        GoapPlanner.Instance.UnregisterState(m_State);
    }
}
