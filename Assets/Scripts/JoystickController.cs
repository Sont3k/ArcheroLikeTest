using UnityEngine;

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
        player.transform.position += new Vector3(joystick.Horizontal * player.MovementSpeed, 0f, joystick.Vertical * player.MovementSpeed);
    }
}
