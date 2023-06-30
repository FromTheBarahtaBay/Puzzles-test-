using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public void LoadNextScene (int numOfScene)
    {
        // загружаем новую сцену
        SceneManager.LoadScene(numOfScene);

        // закрываем старую
        Application.Quit();
    }

    public void SelectImage ()
    {
        // сгружаем передаваемые данные в DataHolder
        Texture2D image = transform.GetComponent<Image>().sprite.texture;

        DataHolder.Image = image;
    }

    public void SelectNumberOfSeparating()
    {
        // сгружаем передаваемые данные в DataHolder
        TextMeshProUGUI _text = GetComponentInChildren<TextMeshProUGUI>();

        DataHolder.Text = _text.text;        
    }
}
