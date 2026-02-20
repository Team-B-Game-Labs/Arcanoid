using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    
    public void SetExclusiveFullscreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.ExclusiveFullScreen);
    }

    
    public void SetBorderless()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
    }

    
    public void SetWindowed()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }
}
