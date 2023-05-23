using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    tk2dButton button;

    private void Start()
    {
        button.ButtonPressedEvent += Button_ButtonPressedEvent;
    }

    private void OnDestroy()
    {
        button.ButtonPressedEvent -= Button_ButtonPressedEvent;
    }

    protected virtual void Button_ButtonPressedEvent(tk2dButton source)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
