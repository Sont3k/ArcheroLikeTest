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
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject healthBar;
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
