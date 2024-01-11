using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float range = 5.0f;
    public Vector3 Destination { get; set; }
    public bool IsAtDestination => Vector3.Distance(transform.position, Destination) < range;
    public float MoveSpeed => moveSpeed;    

    void Update()
    {
        Move();
        RotateTo(Destination);
    }

    private void Move()
    {
        if (IsAtDestination)
            return;

        transform.position = Vector3.MoveTowards(transform.position, Destination, Time.deltaTime * moveSpeed);
    }

    public void RotateTo(Vector3 _targetPosition)
    {
        Vector3 _direction = _targetPosition - transform.position;
        float _yaw = Vector3.Dot(_direction.normalized, transform.right);
        transform.eulerAngles += new Vector3(0, _yaw, 0);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Destination);
        Gizmos.DrawWireSphere(Destination, range);
    }

}
