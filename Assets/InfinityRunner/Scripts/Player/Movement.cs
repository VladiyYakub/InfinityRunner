using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    public void Move(Vector3 direction, float speed)
    {
        _rb.velocity = direction * speed;
    }

    public void StopMove() 
    {
        _rb.velocity = Vector3.zero;
    }

}
