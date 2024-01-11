using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "No time wait transition", menuName = "CORR/Create NoWait Transition")]
public class NoWaitTransition : Transition
{
    public override bool IsTransitionValid => true;
}
