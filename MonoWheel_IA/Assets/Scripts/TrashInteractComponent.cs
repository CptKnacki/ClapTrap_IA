using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class TrashInteractionComponent : MonoBehaviour
{

    [SerializeField] MoveComponent moveComponent = null;
    [SerializeField, Range(0, 90)] int angle = 45;
    public GameObject CurrentTrash { get; set; }


    private void Update()
    {
        DetermineTrashDetection();
    }


    void DetermineTrashDetection()
    {
        RaycastHit _result;


        for (int i = 0; i < 3; i++)
        {
            Vector3 _vectorAngle = Quaternion.Euler(0, -45 + (45 * i), 0) * transform.forward * 20; 
            Ray _ray = new Ray(transform.position, transform.position + _vectorAngle);
            bool _hit = Physics.Raycast(_ray.origin, _ray.direction, out _result, 20, LayerMask.GetMask("Trash"));

            if(_hit)
                CurrentTrash = _result.transform.gameObject;
 
        }

    }
}
