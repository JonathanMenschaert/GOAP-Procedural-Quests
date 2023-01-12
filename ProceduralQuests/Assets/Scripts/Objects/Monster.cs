using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnMouseDown()
    {

        int amount = 0;

        Blackboard.Instance.GetData("AmountSword", ref amount);
        if (amount == 0) return;

        Blackboard.Instance.GetData("AmountMonster", ref amount);
        if (amount > 0)
        {
            Blackboard.Instance.ChangeData("AmountMonster", amount - 1);
        }

        Invoke("Destroy", 0.1f);
    }

    private void Destroy()
    {
       
       Destroy(gameObject);
        
    }
}
