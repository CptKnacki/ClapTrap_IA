using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetNavPointState", menuName = "CORR/Create GetNavPoint State")]
public class FindNavPointRobotState_Corr : State
{


    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);

        owner.FSMOwner.MoveComponent.Destination = owner.FSMOwner.Ground.GetRandomPoint();
        owner.FSMOwner.MoveComponent.DetermineIndexes();
    }
}
