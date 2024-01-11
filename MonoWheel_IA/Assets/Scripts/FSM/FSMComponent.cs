using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    [field: SerializeField] FSM fsmToCreate = null;

    [SerializeField] MoveComponent moveComponent = null;
    //[SerializeField] TrashInteractionComponent trashDetectComponent = null;
    //[SerializeField] MonowheelAnimation monoWheelAnim = null;

    [SerializeField] GroundScript ground = null;
    public GroundScript Ground => ground;

    public MoveComponent MoveComponent => moveComponent;
   // public TrashInteractionComponent TrashDetectComponent => trashDetectComponent;
   // public MonowheelAnimation MonoWheelAnim => monoWheelAnim;



    FSM currentFSM = null;
    
    private void Start()
    {
        Init();
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


    void Init()
    {
        if (!fsmToCreate)
            return;

        currentFSM = Instantiate(fsmToCreate);
        currentFSM.StartSFM(this);

    }

}
