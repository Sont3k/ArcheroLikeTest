using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private Joystick joystick;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f, rigidbody.velocity.y, joystick.Vertical * 10f);
    }
}
