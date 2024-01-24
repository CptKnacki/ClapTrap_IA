using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSightSensor_Corr : SightSensor_Corr
{

    public Vector3 LeftConeDebug => transform.position + Quaternion.Euler(0, sightAngle / 2, 0) * transform.forward * range;
    public Vector3 RightConeDebug => transform.position + Quaternion.Euler(0, - sightAngle / 2, 0) * transform.forward * range;


    public override void UpdateSight()
    {
        Collider[] _items = Physics.OverlapSphere(transform.position, range, hitLayer);

        //Debug.DrawLine(transform.position, LeftConeDebug, Color.green);
        //Debug.DrawLine(transform.position, RightConeDebug, Color.green);


        for (int i = 0; i < _items.Length; i++)
        {
            Vector3 _direction = (_items[i].transform.position - transform.position).normalized;

            float _angle = Vector3.Angle(transform.forward, _direction);


            if(_angle < sightAngle)
            {
                TargetInSight = _items[i].gameObject;
                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        DrawCone(transform.position, transform.forward, sightAngle, range, Color.yellow, 20);
        //Gizmos.DrawWireSphere(transform.position, range);
    }


    void DrawCone(Vector3 _origin, Vector3 _direction, float _angle, float _range, Color _color, int _definition = 10)
    {
        Gizmos.color = _color;

        Vector3 _leftPoint = _origin + Quaternion.Euler(0, (_angle / 2), 0) * _direction * _range;
        Vector3 _rightPoint = _origin + Quaternion.Euler(0, - (_angle / 2), 0) * _direction * _range;
        Vector3 _middlePoint = _origin + _direction * _range;

        Gizmos.DrawLine(_origin, _leftPoint);
        Gizmos.DrawLine(_origin, _rightPoint);



        float _part = _angle / (float)_definition;


        for (int i = 0; i < _definition; i++)
        {
            int _index = i;

            Gizmos.DrawLine(_origin + Quaternion.Euler(0, (_angle / 2) - _part * _index, 0) * _direction * _range,
                _origin + Quaternion.Euler(0, (_angle / 2) - _part * (_index + 1), 0) * _direction * _range);

        }
    }
}
