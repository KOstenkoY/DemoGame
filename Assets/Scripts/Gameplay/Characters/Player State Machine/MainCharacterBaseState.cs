using UnityEngine;

public abstract class MainCharacterBaseState
{
    public abstract void EnterState(MainCharacterStateManager mainCharacterStateManager);
    public abstract void UpdateState(MainCharacterStateManager mainCharacterStateManager);
}
