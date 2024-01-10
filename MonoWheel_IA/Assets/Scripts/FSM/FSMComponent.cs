using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class FSMComponent : MonoBehaviour
{
    [field: SerializeField] FSM fsmToCreate = null;

    [SerializeField] public MoveComponent moveComponent = null;
    [SerializeField] public TrashInteractionComponent trashDetectComponent = null;

    FSM currentFSM = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        if (!fsmToCreate)
            return;

        currentFSM = Instantiate(fsmToCreate);
        currentFSM.StartSFM(this);

    }

    private void Update()
    {
        if (currentFSM)
            currentFSM.UpdateFSM();
    }

    private void OnDestroy()
    {
        if (currentFSM)
            currentFSM.StopFSM();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(moveComponent.Destination, gameObject.transform.position);
        Gizmos.DrawWireCube(moveComponent.Destination, new Vector3(0.5f, 0.5f, 0.5f));
    }


}
