using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonowheelAnimation : MonoBehaviour
{
    [SerializeField] Animator animator = null;

    public bool IsMoving { get; set; } = false;
    public bool IsCleaning { get; set; } = false;

    private void Update()
    {
        animator.SetBool("IsMoving", IsMoving);
        animator.SetBool("IsCleaning", IsCleaning);
    }

}
