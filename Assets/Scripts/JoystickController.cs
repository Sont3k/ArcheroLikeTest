using UnityEngine;
//TODO remove redundant Rigidbody
public class JoystickController : MonoBehaviour
{
    PlayerController player;
    Joystick joystick;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        player.transform.position += new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
    }
}
