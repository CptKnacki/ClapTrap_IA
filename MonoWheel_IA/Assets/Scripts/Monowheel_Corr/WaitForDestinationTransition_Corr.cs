using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaitForDestination", menuName ="CORR/Create WaitForDestination Transition")]
public class WaitForDestinationTransition_Corr : Transition
{


    public override bool IsTransitionValid => owner.FSMOwner.MoveComponent.IsAtDestination;
}
