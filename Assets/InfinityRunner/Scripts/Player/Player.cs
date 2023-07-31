using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IObstacleTrigger
{
    [Header("Health")]
    [SerializeField] private int _maxHealth;
    [Header("Movement")]
    [SerializeField] private Movement _movement;
    [SerializeField] private float _speed;

    private int _currentHealth;

    private HPSlider _hpSlider;

    public event UnityAction<int, int> HealthChanged;

    public void Init(HPSlider hpSlider)
    {
        _hpSlider = hpSlider;
        _currentHealth = _maxHealth;
        _hpSlider.SetHP(_currentHealth, _maxHealth);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis(Axis.Horizontal);

        if (horizontal == 0f)
        {
            _movement.StopMove();
        }
        else
        {
            _movement.Move(new Vector3(horizontal, 0, 0), _speed);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            var currentScene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        _hpSlider.SetHP(_currentHealth);
    }
}
