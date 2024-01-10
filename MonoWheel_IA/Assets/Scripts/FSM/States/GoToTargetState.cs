using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoToTargetState", menuName = "FSM/Create GoToTarget State")]
public class GoToTargetState : State
{


    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);

        owner.FSMOwner.moveComponent.Destination = owner.FSMOwner.trashDetectComponent.CurrentTrash.transform.position;
    }
}
