using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bullet;
    public GameObject firePoint;
    public float timeBetweenShots;
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

    public void Shoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots / 10;

            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    public void FindEnemies()
    {
        GameObject[] objects = Object.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objects)
        {
            if(obj.tag == "Enemy")
            {
                enemies.Add(obj);
            }
        }
    }

    public void DealDamage()
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
