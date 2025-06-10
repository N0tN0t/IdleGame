using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("Game");
    }
}
