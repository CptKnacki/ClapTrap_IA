using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "FSM/Create Idle State")]
public class IdleState : State
{

    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);

        //owner.FSMOwner.MoveComponent.Destination = owner.FSMOwner.transform.position;
        //
        //owner.FSMOwner.MonoWheelAnim.IsCleaning = false;
        //owner.FSMOwner.MonoWheelAnim.IsMoving = false;

    }
}
