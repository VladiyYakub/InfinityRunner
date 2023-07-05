using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ApplyDamage(_damage);
        }
    }
}
