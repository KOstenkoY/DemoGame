using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterSlowRunningState : MainCharacterBaseState
{
    private float _slowingSpeed = 250f;
    private float _slowingTimeScale = 0.75f;

    private float _slowingRunTime = 2f;

    private bool _checkSwitchState = false;

    public override void EnterState(MainCharacterStateManager mainCharacter)
    {
        _checkSwitchState = false;

        mainCharacter.SetAnimation(mainCharacter.RunningAnimationStateName, true);
        mainCharacter.SetAnimationTimeScale(_slowingTimeScale);

        mainCharacter.StartCoroutine(SlowingRunRoutine());
    }

    public override void UpdateState(MainCharacterStateManager mainCharacter)
    {
        if (_checkSwitchState)
            mainCharacter.SwitchState(mainCharacter.mainCharacterRunninState);
        else
            mainCharacter.transform.Translate(Vector2.left.x * _slowingSpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator SlowingRunRoutine()
    {
        yield return new WaitForSeconds(_slowingRunTime);

        _checkSwitchState = true;
    }
}
