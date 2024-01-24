using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    [field: SerializeField] public GridPointData Grid { get; set; }
    [field: SerializeField] public Vector3 Position { get; set; }
    [field: SerializeField] public List<int> Successors { get; private set; } = new();
    [field: SerializeField] public bool IsSelected { get; set; } = false;

    //NAV
    [field: SerializeField] public float G { get; set; } = float.MaxValue; // distance depuis le départ //
    [field: SerializeField] public float H { get; set; } = float.MaxValue; // distance vers l'arrivé //
    public float F => G + H; // coût total //
    [field: SerializeField] public Node Parent { get; set; }


    public void AddSuccessor(int _successor) => Successors.Add(_successor);
    public void DrawGizmos(Color _nodeColor, Color _lineColor)
    {
        Gizmos.color = _nodeColor;
        Gizmos.DrawSphere(Position, .2f);

        if (!IsSelected)
            return;

        Gizmos.color = _lineColor;
        for (int i = 0; IsSelected && i < Successors.Count; i++)
        {
            Gizmos.DrawLine(Position, Grid.Nodes[Successors[i]].Position);
        }
    }

    public void ResetNode()
    {
        H = float.MaxValue;
        G = float .MaxValue;
        Parent = null;
    }
}