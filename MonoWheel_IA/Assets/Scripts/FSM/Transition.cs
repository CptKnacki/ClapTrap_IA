using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Transition : ScriptableObject
{
    [SerializeField] State nextState = null;
    // COST de la transition pour établir une priorité
    public State NextState { get { return nextState; } }

    protected FSM owner = null;

    public virtual bool IsTransitionValid { get; } = false;

    public virtual void InitTransition(FSM _owner)
    {
        owner = _owner;
    }


}
