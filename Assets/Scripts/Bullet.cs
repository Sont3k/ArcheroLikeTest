using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100;
    public float lifetime = 5;
    public Transform direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveAlongDirection();
        DestroyOverTime();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //TODO Deal damage to enemy
        }

        Destroy(gameObject);
    }

    private void DestroyOverTime()
    {
        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void MoveAlongDirection()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction.position, speed * Time.deltaTime);
    }
}
