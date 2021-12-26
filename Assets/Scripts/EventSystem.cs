using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CpuEvent
{


    public class EventSystem : MonoBehaviour
    {
        public List<IListener> listeners = new List<IListener>();

        public void Register(IListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
            listeners.Add(listener);
        }

        public void RaiseAllListeners()
        {
            foreach (IListener listener in listeners)
            {
                listener.Raise();
            }
        }
    }

    public interface IListener
    {
        void Raise();
    }
}