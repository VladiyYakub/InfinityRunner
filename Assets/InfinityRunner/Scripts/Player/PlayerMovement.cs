using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private void Update()
    {
        float horizontal = Input.GetAxis(Axis.Horizontal);      

        _movement.Move(new Vector3(horizontal, 0, 0));
    }
}
