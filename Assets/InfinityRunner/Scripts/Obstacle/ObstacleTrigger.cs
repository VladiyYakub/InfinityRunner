using UnityEngine;
using UnityEngine.SceneManagement;
public class ObstacleTrigger : MonoBehaviour, IObstacleTrigger
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ApplyDamage(_damage);
        }
    }
    public void ApplyDamage(int damage)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
