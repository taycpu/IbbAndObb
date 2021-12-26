using UnityEngine.Events;

namespace CpuStateMachine
{
    public class State
    {
        public UnityEvent enterStateAct;
        public UnityEvent updateStateAct;
        public UnityEvent exitStateAct;

        public void EnterState()
        {
            enterStateAct?.Invoke();
        }

        public void UpdateState()
        {
            updateStateAct?.Invoke();
        }

        public void ExitState()
        {
            exitStateAct?.Invoke();
        }
    }
}