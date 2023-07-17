using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetHP(float normalizedHP)
    {
        _slider.value = normalizedHP;
    }
}
