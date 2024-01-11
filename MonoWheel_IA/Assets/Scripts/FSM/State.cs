using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] Transition[] transitions = null;

    protected List<Transition> runningTransitions = new();
    protected FSM owner = null;


    public virtual void Enter(FSM _fsm)
    {
        owner = _fsm;
        InitTransitions();

        Debug.Log("Enter in state -> " + name);
    }

    public virtual void Update()
    {
        CheckForValidTransitions();

        // Debug.Log("Update state -> " + name);
    }

    public virtual void Exit()
    {

        Debug.Log("Exit out of state -> " + name);
    }

    protected virtual void InitTransitions()
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            if (!transitions[i])
                continue;

            Transition _tr = Instantiate(transitions[i]);
            _tr.InitTransition(owner);
            runningTransitions.Add(_tr);
        }
    }

    protected virtual void CheckForValidTransitions()
    {
        for (int i = 0; i < runningTransitions.Count; i++)
        {
            if (runningTransitions[i] && runningTransitions[i].IsTransitionValid)
            {
                Exit();
                owner.SetNextState(runningTransitions[i].NextState);
                return;
            }
        }
    }

}
