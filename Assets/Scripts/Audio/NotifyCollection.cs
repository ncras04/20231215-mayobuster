using System.Collections.Generic;
using UnityEngine;

public class NotifyCollection<T> : ScriptableObject
{
    public List<T> Data => new List<T>(m_data);

    public event System.Action<T> OnAdd
    {
        add
        {
            m_onAdd -= value;
            m_onAdd += value;
        }
        remove
        {
            m_onAdd -= value;
        }
    }

    public event System.Action<T> OnRemove
    {
        add
        {
            m_onRemove -= value;
            m_onRemove += value;
        }
        remove
        {
            m_onRemove -= value;
        }
    }

    private List<T> m_data = new List<T>();

    private event System.Action<T> m_onRemove;
    private event System.Action<T> m_onAdd;

    /// <summary>
    /// Adds a request to a list for the assigned manager
    /// </summary>
    /// <param name="_obj">Requested Event</param>
    public void Add(T _obj)
    {
        m_data.Add(_obj);
        m_onAdd?.Invoke(_obj);
    }

    public void Remove(T _obj)
    {
        m_data.Remove(_obj);
        m_onRemove?.Invoke(_obj);
    }
}