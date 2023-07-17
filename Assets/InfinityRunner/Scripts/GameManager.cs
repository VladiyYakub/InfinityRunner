using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HPSlider _hpSlider;

    private void Start()
    {
        _player.Init(_hpSlider);
    }
}