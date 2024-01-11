using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.GridLayoutGroup;

public class TrashInteractionComponent : MonoBehaviour
{

    [SerializeField, Range(0, 90)] int angle = 45;
    [SerializeField, Range(5, 25)] float detectRange = 10;
    public GameObject CurrentTrash { get; set; } = null;
    public Vector3 CurrentTrashPosition { get {  return CurrentTrash ? CurrentTrash.transform.position : transform.position; } }
    public bool IsAtCurrentTrashRange => Vector3.Distance(transform.position, CurrentTrashPosition) < 3.0f;


    private void Update()
    {
        DetermineTrashDetection();
    }


    void DetermineTrashDetection()
    {
        if (CurrentTrash)
            return;

        Vector3 _middle = transform.forward * detectRange,
                _left = Quaternion.Euler(0, -angle, 0) * _middle,
                _right = Quaternion.Euler(0, angle, 0) * _middle;

        RaycastForTrashDetection(transform.position, _left, detectRange);
        RaycastForTrashDetection(transform.position, _middle, detectRange);
        RaycastForTrashDetection(transform.position, _right, detectRange);

        //float _distance = Vector3.Distance(transform.position + _left, transform.position + _right);
        //Ray _sphereRay = new Ray(transform.position + _middle, )
        //Physics.SphereCast();
        //Physics2D.CircleCast();


    }

    void RaycastForTrashDetection(Vector3 _from, Vector3 _to, float _range)
    {
        RaycastHit _result;

        Ray _ray = new Ray(_from, _to);
        bool _hit = Physics.Raycast(_ray.origin, _ray.direction, out _result, _range, LayerMask.GetMask("Trash"));

        if (_hit)
        {
            CurrentTrash = _result.transform.gameObject;
            return;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if(CurrentTrash)
        {

            Gizmos.DrawLine(transform.position, CurrentTrashPosition);
            Gizmos.DrawWireCube(CurrentTrashPosition, new Vector3(0.5f, 0.5f, 0.5f));
        }

        Vector3 _left = Quaternion.Euler(0, -angle, 0) * transform.forward * detectRange,
                _right = Quaternion.Euler(0, angle, 0) * transform.forward * detectRange,
                _middle = transform.forward * detectRange;



        Gizmos.color = CurrentTrash ? Color.red : Color.yellow;

        MonowheelAnimation _anim = GetComponent<MonowheelAnimation>();
        if(_anim)
        {
            if (!_anim.IsCleaning && !_anim.IsMoving)
                Gizmos.color = Color.green;
        }

        Gizmos.DrawLine(transform.position, transform.position + _left);
        Gizmos.DrawLine(transform.position, transform.position + _right);
        Gizmos.DrawLine(transform.position + _left, transform.position + _middle);
        Gizmos.DrawLine(transform.position + _right, transform.position + _middle);


    
        
    }
}
