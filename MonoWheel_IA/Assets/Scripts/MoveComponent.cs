using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    public Vector3 Destination { get; set; }
    public bool CanMove => Vector3.Distance(transform.position, Destination) > 0.1f;


    void Start()
    {

    }

    void Update()
    {
        Move();
        RotateTo();
    }

    private void Move()
    {
        if (CanMove)
        {
            // RAJOUTER UN LOOK AT DE LA DESTINATION //

            transform.position = Vector3.MoveTowards(transform.position, Destination, Time.deltaTime * moveSpeed);
            
        }
    }

    void RotateTo()
    {
        if (CanMove)
        {
            Vector3 _direction = Destination - transform.position;
            float _yaw = Vector3.Dot(_direction.normalized, transform.right);
            transform.eulerAngles += new Vector3(0, _yaw, 0);
        }
    }



}
