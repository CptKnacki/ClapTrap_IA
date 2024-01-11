using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoToTargetState", menuName = "FSM/Create GoToTarget State")]
public class GoToTargetState : State
{


    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);

        //Vector3 _destination = owner.FSMOwner.TrashDetectComponent.CurrentTrashPosition;
        //_destination.y = owner.FSMOwner.transform.position.y;
        //
        //owner.FSMOwner.MoveComponent.Destination = _destination;
    }
}
