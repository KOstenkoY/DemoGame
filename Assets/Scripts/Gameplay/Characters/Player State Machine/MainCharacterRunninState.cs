using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterRunninState : MainCharacterBaseState
{
    private float _runningSpeed = 425f;
    private float _timeScale = 1f;

    public override void EnterState(MainCharacterStateManager mainCharacter)
    {
        mainCharacter.SetAnimation(mainCharacter.RunningAnimationStateName, true);
        mainCharacter.SetAnimationTimeScale(_timeScale);
    }

    public override void UpdateState(MainCharacterStateManager mainCharacter)
    {
        mainCharacter.transform.Translate(Vector2.right.x * _runningSpeed * Time.deltaTime, 0, 0);
    }
}
