using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CleanDirtState", menuName = "CORR/Create CleanDirt State")]
public class CleanDirtSate_Corr : State
{
    [SerializeField] int cleanTime = 5;

    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);
        SightSensor_Corr _sight = owner.FSMOwner.GetComponent<SightSensor_Corr>();
        Destroy(_sight.TargetInSight, cleanTime);
    }

}
