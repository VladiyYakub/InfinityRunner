using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour, IObstacleTrigger
{
    [SerializeField] private int health = 3;

    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {           
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
