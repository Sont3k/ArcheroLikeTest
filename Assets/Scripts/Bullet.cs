using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Player")
        // {
        //     PlayerHealthController.instance.DealDamage();
        // }

        Destroy(gameObject);
    }
}
