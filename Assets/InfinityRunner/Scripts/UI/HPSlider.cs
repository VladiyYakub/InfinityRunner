using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    private const float DoNotChangeMaxHP = -1f;

    [SerializeField] private Slider _slider;
    [SerializeField] private float _maxHP;

    public void SetHP(float currentHP, float newMaxHPValue = DoNotChangeMaxHP)
    {
        _maxHP = newMaxHPValue == DoNotChangeMaxHP ? _maxHP : newMaxHPValue;
        float normalizedHP = currentHP / _maxHP;
        _slider.value = normalizedHP;
    }
}
