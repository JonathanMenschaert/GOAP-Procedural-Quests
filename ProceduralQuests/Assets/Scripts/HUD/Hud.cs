using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Objective;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Objective != null) 
        {
            string data = "";
            Blackboard.Instance.GetData("Objective",ref data);
            m_Objective.text = data;
        }
    }
}
