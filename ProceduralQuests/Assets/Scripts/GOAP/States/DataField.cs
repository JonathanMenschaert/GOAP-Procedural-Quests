using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataField<T> : IDataField
{
    private T m_Value;

    public DataField(T value)
    {
        m_Value = value;
    }

    public T Value
    { 
        get { return m_Value; } 
        set { m_Value = value; }
    }
}
