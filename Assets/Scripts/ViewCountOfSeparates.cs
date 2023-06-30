using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewCountOfSeparates : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private Slider _slider;

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();

        _slider = GetComponentInChildren<Slider>();
    }

    public void ShowTheChoosenNumbers()
    {
        _text.text = _slider.value.ToString();
    }
}
