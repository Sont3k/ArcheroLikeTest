using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePoint;
    [SerializeField] float timeBetweenShots;
    private float shotCounter;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = .4f;
    public float MovementSpeed { get => movementSpeed; }

    public void Shoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots / 10;

            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
