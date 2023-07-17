using UnityEngine;
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IObstacleTrigger[] obstacleTriggers = other.GetComponents<IObstacleTrigger>();
        if (obstacleTriggers != null)
        {
            foreach (var obstacleTrigger in obstacleTriggers)
            {
                obstacleTrigger.ApplyDamage(1);
            }
        }
    }
}
