using UnityEngine;
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IObstacleTrigger obstacleTrigger = other.GetComponent<IObstacleTrigger>();
        if (obstacleTrigger != null)
        {
            obstacleTrigger.ApplyDamage(1);
        }
    }
}
