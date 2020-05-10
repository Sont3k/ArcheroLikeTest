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
        if(joystick.Horizontal <= Mathf.Epsilon && joystick.Vertical <= Mathf.Epsilon)
        {
            PlayerShoot();
        }
        else
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        player.transform.position += new Vector3(joystick.Horizontal * player.movementSpeed, 0f, joystick.Vertical * player.movementSpeed);
    }

    private void PlayerShoot()
    {
        player.Shoot();
    }
}
