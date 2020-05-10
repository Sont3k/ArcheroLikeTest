using UnityEngine;
//TODO implement Flyer logic
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
    public GameObject firePoint;
    public int damage;

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
        CheckMovementDirection();
        Move();
    }

    private void CheckMovementDirection()
    {
        if (movingForward)
        {
            if (Vector3.Distance(transform.position, point_2.transform.position) < 1)
            {
                movingForward = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, point_1.transform.position) < 1)
            {
                movingForward = true;
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

    public void DealDamage()
    {
        // Realize shooting
    }
}