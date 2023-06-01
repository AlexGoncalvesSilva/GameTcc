using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameMenu : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
