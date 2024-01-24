using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    Vector3 point = Vector3.zero;

    public Vector3 GetRandomPoint()
    {

        float _sizeX = (transform.localScale.x -1) * 10,
              _sizeZ = (transform.localScale.z -1) * 10;

        float _x = Random.Range(-_sizeX * 0.5f, _sizeX * 0.5f),
              _z = Random.Range(-_sizeZ * 0.5f, _sizeZ * 0.5f);

       return point = new Vector3(_x, 0, _z);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(point, 0.3f);
    }
}
