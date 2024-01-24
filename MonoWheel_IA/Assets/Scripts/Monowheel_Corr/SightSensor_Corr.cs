using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SightSensor_Corr : MonoBehaviour
{
    [SerializeField, Range(0, 360)] protected int sightAngle = 90;
    [SerializeField] protected int range = 5;
    [SerializeField] protected LayerMask hitLayer;
    [SerializeField] int definition = 5;
    [SerializeField] float sightHeight = 0.5f;

    public GameObject TargetInSight { get; protected set; }

    private void Update()
    {
        // Eviter de faire le test à chaque tick pour ne pas casser les performances
        UpdateSight();
    }

    public virtual void UpdateSight()
    {
        Vector3 _offset = new Vector3( 0, sightHeight, 0);
        Vector3 _origin = transform.position + _offset;
        Vector3 _to;

        if(TargetInSight)
        {
            Debug.DrawLine(_origin, TargetInSight.transform.position, Color.yellow);
            return;
        }

        for (int i = -(sightAngle / 2); i < sightAngle / 2; i += definition)
        {

            Vector3 _angle = transform.position + Quaternion.Euler(0, i, 0) * (transform.forward * range) + (_offset * Mathf.Sin(Time.time));
            _to = _angle;

           bool _impact = Physics.Raycast(_origin, _to - _origin, out RaycastHit _hit, range, hitLayer);

            Debug.DrawRay(_origin, _to - _origin, TargetInSight ? Color.green : Color.red);

            if(_impact) 
            {
                TargetInSight = _hit.collider.gameObject;
                return;
            }
        }
    }

    public void ClearSight() => TargetInSight = null;

}
