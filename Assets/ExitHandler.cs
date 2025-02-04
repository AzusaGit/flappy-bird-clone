using UnityEngine;

public class ExitHandler : MonoBehaviour
{
    void OnApplicationQuit()
    {
        if (!Application.isEditor)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
