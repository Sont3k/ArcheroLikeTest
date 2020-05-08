using UnityEngine;
// TODO fix crawler moving
public class Crawler : MonoBehaviour
{
    PlayerController player;
    CharacterController characterController;

    [SerializeField] float movementSpeed = 200f;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveTowardPlayer();
    }

    private void MoveTowardPlayer()
    {
        // float step = movementSpeed * Time.deltaTime;
        // Vector3 currentPlayerPos = player.transform.position;

        // if (Vector3.Distance(transform.position, player.transform.position) > 0.001f)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        // }

        Vector3 dir = player.transform.position - transform.position;
        var movement = dir.normalized * movementSpeed * Time.deltaTime;

        if(movement.magnitude > dir.magnitude)
        {
            movement = dir;
        }

        characterController.Move(movement);
    }
}
