using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[RequireComponent(typeof(SkeletonAnimation))]
public class MainCharacterStateManager : MonoBehaviour
{
    public MainCharacterBaseState _currentState;
    // our states
    public MainCharacterSlowRunningState mainCharacterSlowRunningState = new MainCharacterSlowRunningState();
    public MainCharacterRunninState mainCharacterRunninState = new MainCharacterRunninState();
    public MainCharacterAccelerationRunningState mainCharacterAccelerationRunningState = new MainCharacterAccelerationRunningState();

    private SkeletonAnimation _skeletonAnimation;

    private string _currentAnimationName = null;

    private const string runningAnimationStateName = "run";

    public string RunningAnimationStateName => runningAnimationStateName;

    private void Awake()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    private void Start()
    {
        // starting state for the state machine
        _currentState = mainCharacterAccelerationRunningState;
        // "this" is a reference to the context (this EXACT Monobehavior script)
        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SetAnimation(string name, bool loop, int trackIndex = 0)
    {
        if (name == _currentAnimationName)
            return;

        _skeletonAnimation.state.SetAnimation(trackIndex, name, loop);
        _currentAnimationName = name;
    }

    public void SetAnimationTimeScale(float timeScale)
    {
        _skeletonAnimation.timeScale = timeScale;
    }

    public void SwitchState(MainCharacterBaseState state)
    {
        _currentState = state;

        state.EnterState(this);
    }
}
