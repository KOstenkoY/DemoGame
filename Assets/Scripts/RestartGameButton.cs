using UnityEngine.SceneManagement;

public class RestartGameButton : ExitButton
{
    protected override void Button_ButtonPressedEvent(tk2dButton source)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
