using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bullet;
    public GameObject firePoint;
    public float attackRange;
    public float timeBetweenShots;
    public float bulletSpeed;
    private float shotCounter;
    private List<GameObject> enemies = new List<GameObject>();

    [Header("Movement")]
    public float movementSpeed = .4f;

    [Header("Health")]
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject healthBar;
    HealthBarController healthBarController;

    private void Start()
    {
        InitHealth();
        FindEnemies();
    }

    private void InitHealth()
    {
        healthBarController = healthBar.GetComponent<HealthBarController>();
        healthBarController.SetMaxHealth(maxHealth);
        healthBarController.SetHealth(maxHealth);

        currentHealth = maxHealth;
    }

    public void InitShoot()
    {
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < attackRange)
            {
                transform.LookAt(enemy.transform);

                StartShooting(enemy.transform);
            }
        }
    }

    public void StartShooting(Transform enemy)
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots / 10;

            bullet.GetComponent<Bullet>().direction = enemy;
            bullet.GetComponent<Bullet>().speed = bulletSpeed;

            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    public void FindEnemies()
    {
        GameObject[] objects = Object.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.tag == "Enemy")
            {
                enemies.Add(obj);
            }
        }
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0)
        {
            healthBarController.SetHealth(currentHealth);
            Destroy(gameObject);
        }
        else
        {
            currentHealth--;
            healthBarController.SetHealth(currentHealth);
        }
    }
}
