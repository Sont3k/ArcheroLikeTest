using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePoint;
    [SerializeField] float timeBetweenShots;
    private float shotCounter;

    [Header("Movement")]
    [SerializeField] float movementSpeed = .4f;
    public float MovementSpeed { get => movementSpeed; }

    [Header("Health")]
    [SerializeField] int health = 5;
    public int Health { get => health; set { health = value; } }

    public void Shoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots / 10;

            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    public void DealDamage()
    {
        if (health <= 1)
        {
            Destroy(gameObject);
        }

        health--;
    }
}
