using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    GameObject visual;
    [SerializeField]
    tk2dButton buttonOpenWindow;
    [SerializeField]
    tk2dButton buttonCloseWindow;

    public event System.Action OnOpen;
    public event System.Action OnClose;


    private void Start()
    {
        if(buttonOpenWindow != null)
            buttonOpenWindow.ButtonPressedEvent += ButtonOpenWindow_ButtonPressedEvent; ;
        if (buttonCloseWindow != null)
            buttonCloseWindow.ButtonPressedEvent += ButtonCloseWindow_ButtonPressedEvent;
    }

    private void OnDestroy()
    {
        if (buttonOpenWindow != null)
            buttonOpenWindow.ButtonPressedEvent -= ButtonOpenWindow_ButtonPressedEvent; ;
        if (buttonCloseWindow != null)
            buttonCloseWindow.ButtonPressedEvent -= ButtonCloseWindow_ButtonPressedEvent;
    }

    private void ButtonOpenWindow_ButtonPressedEvent(tk2dButton source)
    {
        Open();
    }

    private void ButtonCloseWindow_ButtonPressedEvent(tk2dButton source)
    {
        Close();
    }

    public virtual void Open()
    {
        visual.SetActive(true);
        OnOpen?.Invoke();
    }    

    public void Close()
    {
        visual.SetActive(false);
        OnClose?.Invoke();
    }
}
