using System.Collections;
using CpuMisc;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private StateMachineMono stateMachine;


    private void Start()
    {
        Initialize();
    }


    public override void Initialize()
    {
        stateMachine.Initialize();
    }


    public void ChangeGameState(int index)
    {
        stateMachine.ChangeState(index);
    }
}