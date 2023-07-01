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
        // загружаем сцену 0 с выбором картинки
        SceneManager.LoadScene(0);
    }
}
