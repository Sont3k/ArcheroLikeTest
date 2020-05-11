using System.Collections;
using UnityEngine;

public class Crawler : MonoBehaviour, IEnemy, IMeleeAttack
{
    PlayerController player;
    CharacterController characterController;

    public float movementSpeed = 200f;
    public float timeBetweenDamage = 4;
    private float damageCounter;

    [Header("Health")]
    public int health;

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
        if (player)
        {
            float step = movementSpeed * Time.deltaTime;
            Vector3 currentPlayerPos = player.transform.position;

            if (Vector3.Distance(transform.position, player.transform.position) < 10f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            }

            // Vector3 dir = player.transform.position - transform.position;
            // var movement = dir.normalized * movementSpeed * Time.deltaTime;

            // if (movement.magnitude > dir.magnitude)
            // {
            //     movement = dir;
            // }

            // characterController.Move(movement);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DealDamage(other));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            TakeDamage();
        }
    }

    public IEnumerator DealDamage(Collision other)
    {
        player.TakeDamage();
        yield return new WaitForSeconds(1f);
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
