using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class MainCharacterMovement : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    private Spine.AnimationState _animationState;

    private void Awake()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
       _animationState = _skeletonAnimation.AnimationState;

        Spine.TrackEntry trackEntry = _animationState.SetAnimation(0, "run rn", true);
    }
}
