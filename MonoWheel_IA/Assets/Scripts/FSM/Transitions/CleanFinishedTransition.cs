using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CleanFinishedTransition", menuName = "FSM/Create CleanFinished Transition")]
public class CleanFinishedTransition : Transition
{
    [SerializeField] float cleanTime = 3.0f;
    bool hasCleaned = false;

    //public override bool IsTransitionValid => hasCleaned || !owner.FSMOwner.TrashDetectComponent.CurrentTrash;

    public override void InitTransition(FSM _owner)
    {
        base.InitTransition(_owner);
        owner.FSMOwner.StartCoroutine(Clean());
    }

    IEnumerator Clean()
    {
        yield return new WaitForSeconds(cleanTime);
        hasCleaned = true;

        //Destroy(owner.FSMOwner.TrashDetectComponent.CurrentTrash);
    }

}
