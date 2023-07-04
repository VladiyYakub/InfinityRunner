using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private void Update()
    {
        float horizontal = Input.GetAxis(Axis.Horizontal);
        //float vertical = Input.GetAxis(Axis.Vertical);       

        //_movement.Move(new Vector3(horizontal, 0, vertical));

        _movement.Move(new Vector3(horizontal, 0, 0));


    }
}
