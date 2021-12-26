using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            if (useEvent)
            {
                for (int i = 0; i < listener.Count; i++)
                {
                    listener[i].Raise();
                }
            }
        }
    }

    public bool useEvent;
    [SerializeField] private int _value;
    [SerializeField] private List<IListener> listener = new List<IListener>();
}