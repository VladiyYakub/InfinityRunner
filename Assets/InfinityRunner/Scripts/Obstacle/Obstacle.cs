using UnityEngine;
public class Obstacle : MonoBehaviour
{   
    private void OnCollisionEnter(Collision collision)
    {
        IObstacleTrigger obstacleTrigger = collision.gameObject.GetComponent<IObstacleTrigger>();
        if (obstacleTrigger != null)
        {
            obstacleTrigger.ApplyDamage(1);
        }       
    }
}
