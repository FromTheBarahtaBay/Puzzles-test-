using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndExit : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        // загружаем новую сцену
        SceneManager.LoadScene(0);

        // закрываем старую
        Application.Quit();
    }
}
