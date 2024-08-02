using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetScaleValue : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private float _scaleValue;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Slider _slider;
    
    // set the scale value to scale-value
    public void SetValue()
    {
        if (_textMeshPro == null || _slider == null)
            return;

        _textMeshPro.text = _slider.value.ToString();
    }
}
