using System.Collections;
using UnityEngine;

public class Flyer : MonoBehaviour, IEnemy, IRangedAttack
{
    PlayerController player;
    CharacterController characterController;

    [Header("Flying")]
    public float horizontalSpeed;
    // public float verticalSpeed;
    // public float amplitude;
    public GameObject point_1, point_2;
    private bool movingForward = true;

    [Header("Shooting")]
    public GameObject bullet;
    public GameObject firePoint;
    public float attackRange;
    public float bulletSpeed;

    [Header("Health")]
    public int health;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        characterController = GetComponent<CharacterController>();
        InitPosition();
    }

    private void InitPosition()
    {
        point_1.transform.parent = null;
        point_2.transform.parent = null;
        transform.position = point_1.transform.position;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            StartCoroutine(CheckMovementDirection());
        }

        Move();
    }

    private IEnumerator CheckMovementDirection()
    {
        if (movingForward)
        {
            if (Vector3.Distance(transform.position, point_2.transform.position) < 1)
            {
                movingForward = false;

                InitShooting();
                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, point_1.transform.position) < 1)
            {
                movingForward = true;

                InitShooting();
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void Move()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, point_2.transform.position, horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, point_1.transform.position, horizontalSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            TakeDamage();
        }
    }

    public void InitShooting()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            transform.LookAt(player.transform);

            StartShooting(player.transform);
        }
    }

    public void StartShooting(Transform enemy)
    {
        bullet.GetComponent<Bullet>().direction = enemy;
        bullet.GetComponent<Bullet>().speed = bulletSpeed;

        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
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