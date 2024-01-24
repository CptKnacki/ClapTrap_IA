using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GoToDirt", menuName ="CORR/ Create GoToDirt State")]
public class GoToDirtState_Corr : State
{
    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);
        GoToDirt();
    }

    void GoToDirt()
    {
        SightSensor_Corr _sight = owner.FSMOwner.GetComponent<SightSensor_Corr>();

        if(_sight && _sight.TargetInSight)
        owner.FSMOwner.MoveComponent.Destination = _sight.TargetInSight.transform.position;
        owner.FSMOwner.MoveComponent.DetermineIndexes();
    }
}
