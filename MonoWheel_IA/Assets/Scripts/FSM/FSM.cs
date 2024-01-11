using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FSM", menuName = "FSM/Create FSM")]
public class FSM : ScriptableObject
{
    [field: SerializeField] public State StartingState { get; set; }
    public FSMComponent FSMOwner { get; set; }
    public State CurrentState { get; set; }




    public void StartSFM(FSMComponent _fsm)
    {
        FSMOwner = _fsm;
        SetNextState(StartingState);
    }

    public void UpdateFSM()
    {
        if(CurrentState)
            CurrentState.Update();
    }

    public void StopFSM()
    {
        if (CurrentState)
            CurrentState.Exit();
    }


    public void SetNextState(State _nextState)
    {
        if (!_nextState)
            return;

        CurrentState = Instantiate(_nextState);
        CurrentState.Enter(this);
    }

    
}
