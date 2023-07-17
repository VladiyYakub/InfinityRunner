using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour, IObstacleTrigger
{
    [SerializeField] private int _health;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {           
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
