using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IObstacleTrigger
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private HPSlider _hpSlider;

    public event UnityAction<int, int> HealthChanged;

    public void Init(HPSlider hpSlider)
    {
        _hpSlider = hpSlider;
        _currentHealth = _maxHealth;
        UpdateHP();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateHP()
    {
        if (_hpSlider != null)
        {
            float normalizedHP = (float)_currentHealth / _maxHealth;
            _hpSlider.SetHP(normalizedHP);
        }
    }
}
