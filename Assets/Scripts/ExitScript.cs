using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        
    }
}
