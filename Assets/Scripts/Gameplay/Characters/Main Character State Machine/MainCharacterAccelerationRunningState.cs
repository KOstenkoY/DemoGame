using System.Collections;
using UnityEngine;

public class MainCharacterAccelerationRunningState : MainCharacterBaseState
{
    private float _accelerationSpeed = 700f;
    private float _accelerationTimeScale = 1f;

    private float _accelerationRunTime = 9f;

    private bool _checkSwitchState = false; 

    public override void EnterState(MainCharacterStateManager mainCharacter)
    {
        _checkSwitchState = false;

        mainCharacter.SetAnimation(mainCharacter.RunningAnimationStateName, true);
        mainCharacter.SetAnimationTimeScale(_accelerationTimeScale);

        mainCharacter.StartCoroutine(AccelerationRunRoutine());
    }

    public override void UpdateState(MainCharacterStateManager mainCharacter)
    {
        if (_checkSwitchState)
            mainCharacter.SwitchState(mainCharacter.mainCharacterSlowRunningState);
        else
            mainCharacter.transform.Translate(Vector2.right.x * _accelerationSpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator AccelerationRunRoutine()
    {
        yield return new WaitForSeconds(_accelerationRunTime);

        _checkSwitchState = true;
    }
}
