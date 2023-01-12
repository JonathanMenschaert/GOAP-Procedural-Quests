using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Object : MonoBehaviour
{
    [SerializeField]
    private string m_InputName;

    [SerializeField]
    private string m_BlackboardName;

    [SerializeField]
    private bool m_ShouldDestroyAfterClick;

    private TextMeshProUGUI m_ObjectName;

    // Start is called before the first frame update
    void Start()
    {
        m_ObjectName = GetComponentInChildren<TextMeshProUGUI>();
        m_ObjectName.text = m_InputName;


    }

   

    private void OnMouseDown()
    {
        int amount = 0;
        Blackboard.Instance.GetData(m_BlackboardName, ref amount);
        Blackboard.Instance.ChangeData(m_BlackboardName, amount + 1);

        Invoke("Destroy", 0.1f);

        
    }

    private void Destroy()
    {
        if (m_ShouldDestroyAfterClick)
        {
            Destroy(gameObject);
        }
    }
}
