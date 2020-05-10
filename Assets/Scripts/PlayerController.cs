using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bullet;
    public GameObject firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Movement")]
    public float movementSpeed = .4f;
    public float MovementSpeed { get => movementSpeed; }

    [Header("Health")]
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject healthBar;
    HealthBarController healthBarController;

    private void Start()
    {
        InitHealth();
    }

    private void InitHealth()
    {
        healthBarController = healthBar.GetComponent<HealthBarController>();
        healthBarController.SetMaxHealth(maxHealth);
        healthBarController.SetHealth(maxHealth);

        currentHealth = maxHealth;
    }

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
        if (currentHealth <= 1)
        {
            Destroy(gameObject);
        }
        else
        {
            currentHealth--;
            healthBarController.SetHealth(currentHealth);
        }
    }
}
