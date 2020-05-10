using UnityEngine;
//TODO implement Flyer logic
public class Flyer : MonoBehaviour, IEnemy
{
    PlayerController player;
    CharacterController characterController;

    public float movementSpeed = 200f;
    public float timeBetweenDamage;
    private float damageCounter;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        // float step = movementSpeed * Time.deltaTime;
        // Vector3 currentPlayerPos = player.transform.position;

        // if (Vector3.Distance(transform.position, player.transform.position) > 0.001f)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        // }

        Vector3 dir = player.transform.position - transform.position;
        var movement = dir.normalized * movementSpeed * Time.deltaTime;

        if (movement.magnitude > dir.magnitude)
        {
            movement = dir;
        }

        characterController.Move(movement);
    }

    public void DealDamage(Collision other)
    {
       
    }
}