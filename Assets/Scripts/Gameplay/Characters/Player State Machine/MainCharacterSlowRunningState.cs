using System.Collections;
using UnityEngine;

public class MainCharacterSlowRunningState : MainCharacterBaseState
{
    private float _slowingSpeed = 310f;
    private float _slowingTimeScale = 0.6f;

    private float _slowingRunTime = 8f;

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
            mainCharacter.transform.Translate(Vector2.right.x * _slowingSpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator SlowingRunRoutine()
    {
        yield return new WaitForSeconds(_slowingRunTime);

        _checkSwitchState = true;
    }
}
