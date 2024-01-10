using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaitForTransition", menuName = "FSM/Create WaitFor Transition")]
public class WaitForTransition : Transition
{

    [SerializeField] int waitTime = 3;
    bool isDone = false;

    public override bool IsTransitionValid => isDone;

    public override void InitTransition(FSM _owner)
    {
        base.InitTransition(_owner);
        _owner.FSMOwner.StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        isDone = true;
    }
}
