using UnityEngine;
// TODO fix crawler moving
public class Crawler : MonoBehaviour, IEnemy, IMeleeAttack
{
    PlayerController player;
    CharacterController characterController;

    public float movementSpeed = 200f;
    public float timeBetweenDamage = 4;
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

    private void OnCollisionEnter(Collision other)
    {
        DealDamage(other);
    }

    public void DealDamage(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            damageCounter -= Time.deltaTime;

            if (damageCounter <= 0)
            {
                player.DealDamage();

                damageCounter = timeBetweenDamage;
            }
        }
    }
}
