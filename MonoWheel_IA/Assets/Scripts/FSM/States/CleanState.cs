using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleanState", menuName = "FSM/Create Clean State")]
public class CleanState : State
{

    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);

        //owner.FSMOwner.MoveComponent.Destination = owner.FSMOwner.transform.position;
        //
        //owner.FSMOwner.MonoWheelAnim.IsCleaning = true;
    }

}
