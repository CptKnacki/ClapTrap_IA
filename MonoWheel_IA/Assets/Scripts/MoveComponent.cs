using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float range = 5.0f;
    public Vector3 Destination { get; set; }
    public bool IsAtDestination => Vector3.Distance(transform.position, Destination) < range;
    public float MoveSpeed => moveSpeed;    


    // NAVIGATION
    [SerializeField] AstarAlgo astar = new();
    [SerializeField] GridPointData data = null;
    int startIndex = 0;
    int endIndex = 0;
    //

    // MOVEMENT
    List<Node> pathToFollow = new();
    Node currentNode = null;
    int indexOfPath = 0;
    float acceptableRange = 0.1f;
    bool hasArrived = false;
    //



    void Update()
    {
        MoveThroughtPath();
        //RotateTo(Destination);
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

    public void DetermineIndexes()
    {
        float _minStartDistance = float.MaxValue,
              _minEndDistance = float.MaxValue;

        for (int i = 0; i < data.Nodes.Count; i++)
        {
            float _distanceFromStart = Vector3.Distance(transform.position, data.Nodes[i].Position);

            if (_distanceFromStart < _minStartDistance)
            {
                _minStartDistance = _distanceFromStart;
                startIndex = i;
            }

            float _distanceFromEnd = Vector3.Distance(Destination, data.Nodes[i].Position);

            if (_distanceFromEnd < _minEndDistance)
            {
                _minEndDistance = _distanceFromEnd;
                endIndex = i;
            }
        }

        astar.ComputePath(data.Nodes[startIndex], data.Nodes[endIndex]);

        indexOfPath = 0;
        hasArrived = false;

        pathToFollow = astar.CorrectPath;
        currentNode = pathToFollow[indexOfPath];
    }

    void MoveThroughtPath()
    {
        if (hasArrived || IsAtDestination)
            return;

        if (currentNode == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, currentNode.Position, Time.deltaTime * moveSpeed);
        RotateTo(currentNode.Position);

        if (Vector3.Distance(transform.position, currentNode.Position) < acceptableRange + 1)
        {
            indexOfPath++;

            if (indexOfPath >= pathToFollow.Count)
            {
                hasArrived = true;
                return;
            }

            currentNode = pathToFollow[indexOfPath];
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Destination, range);
        Gizmos.DrawSphere(Destination, 0.3f);

        astar.DrawPath();
    }
}
