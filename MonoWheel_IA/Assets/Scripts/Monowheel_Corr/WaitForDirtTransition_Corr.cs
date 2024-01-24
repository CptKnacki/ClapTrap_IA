using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaitForDirtTransition", menuName = "CORR/Create WaitForDirt Transition")]
public class WaitForDirtTransition_Corr : Transition
{
    SightSensor_Corr sight = null;

    public override bool IsTransitionValid => sight ? sight.TargetInSight : false;

    public override void InitTransition(FSM _owner)
    {
        base.InitTransition(_owner);
        sight = owner.FSMOwner.GetComponent<SightSensor_Corr>();

    }
}
