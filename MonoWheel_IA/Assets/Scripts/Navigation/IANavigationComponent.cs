using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IANavigationComponent : MonoBehaviour
{
    [SerializeField] AstarAlgo astar = new();

    [SerializeField] GridPointData data = null;
    int startIndex = 0;
    int endIndex = 0;

    [SerializeField] GameObject endTarget = null;

    public Vector3 StartPosition => transform.position;
    public Vector3 EndPosition => endTarget.transform.position;

    // MOVEMENT
    List<Node> pathToFollow = new();
    Node currentNode = null;
    int indexOfPath = 0;
    float acceptableRange = 0.3f;
    float moveSpeed = 5.0f;
    bool hasArrived = false;
    //

    public void Start()
    {
        DetermineIndexes();
        astar.ComputePath(data.Nodes[startIndex], data.Nodes[endIndex]);

        pathToFollow = astar.CorrectPath;
        currentNode = pathToFollow[indexOfPath];
    }

    void DetermineIndexes()
    {
        float _minStartDistance = float.MaxValue,
              _minEndDistance = float.MaxValue;

        for (int i = 0; i < data.Nodes.Count; i++)
        {
            float _distanceFromStart = Vector3.Distance(StartPosition, data.Nodes[i].Position);

            if( _distanceFromStart < _minStartDistance )
            {
                _minStartDistance = _distanceFromStart;
                startIndex = i;
            }

            float _distanceFromEnd = Vector3.Distance(EndPosition, data.Nodes[i].Position);

            if (_distanceFromEnd < _minEndDistance)
            {
                _minEndDistance = _distanceFromEnd;
                endIndex = i;
            }
        }
    }

    private void Update()
    {
        MoveThroughtPath();
    }

    void MoveThroughtPath()
    {
        if (hasArrived)
            return;

        transform.position = Vector3.MoveTowards(transform.position, currentNode.Position + Vector3.up, Time.deltaTime * moveSpeed);
        RotateTowardCurrentDestination();

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

    private void RotateTowardCurrentDestination()
    {
        Vector3 _direction = currentNode.Position - transform.position;
        float _yaw = Vector3.Dot(_direction.normalized, transform.right);
        transform.eulerAngles += new Vector3(0, _yaw, 0);
    }

    public void OnDrawGizmos()
    {
        astar.DrawPath();

        Gizmos.color = Color.red;

        if(endTarget)
        {
            Gizmos.DrawLine(transform.position, data.Nodes[startIndex].Position);
            Gizmos.DrawLine(endTarget.transform.position, data.Nodes[endIndex].Position);
        }
    }
}

