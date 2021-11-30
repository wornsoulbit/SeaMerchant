using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAnimationBehavior : MonoBehaviour
{
    [Header("Component References")]
    public Animator pirateAnimator;

    //Animation String IDs
    private int pirateMovementAnimationID;
    private int pirateAttackAnimationID;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        pirateMovementAnimationID = Animator.StringToHash("Movement");
        pirateAttackAnimationID = Animator.StringToHash("Attack");
    }

    public void UpdateMovementAnimation(float movementBlendValue)
    {
        pirateAnimator.SetFloat(pirateMovementAnimationID, movementBlendValue);
    }

    public void PlayAttackAnimation()
    {
        pirateAnimator.SetTrigger(pirateAttackAnimationID);
    }


}
