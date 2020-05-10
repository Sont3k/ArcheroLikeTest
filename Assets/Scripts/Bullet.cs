using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;

    // Update is called once per frame
    void Update()
    {
        //TODO add direction to near enemy
        transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
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
}
