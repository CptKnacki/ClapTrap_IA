using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu(fileName = "SearchState", menuName = "FSM/Create Search State")]
public class SearchState : State
{

    public override void Enter(FSM _fsm)
    {
        base.Enter(_fsm);

        float _x = Random.Range(-50, 50),
              _z = Random.Range(-50, 50);

        Vector3 _position = new Vector3(_x, 0, _z);

        //_fsm.FSMOwner.MoveComponent.Destination = _position;

        //owner.FSMOwner.MonoWheelAnim.IsMoving = true;
    }

}
