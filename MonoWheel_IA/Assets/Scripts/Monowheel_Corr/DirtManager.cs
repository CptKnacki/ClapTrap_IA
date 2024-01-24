using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DirtManager : MonoBehaviour
{

    [SerializeField] GameObject dirtObject = null;
    [SerializeField] GroundScript ground = null;

    void Start()
    {
        InvokeRepeating(nameof(SpawnDirt), 0, 40);
    }

    void SpawnDirt()
    {
        Instantiate(dirtObject, ground.GetRandomPoint() + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
