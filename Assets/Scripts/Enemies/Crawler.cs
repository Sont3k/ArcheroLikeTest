using UnityEngine;

public class Crawler : MonoBehaviour
{
    PlayerController player;

    [SerializeField] float movementSpeed = 200f;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        UpdateEnemyPosition();
    }

    private void UpdateEnemyPosition()
    {
        float step = movementSpeed * Time.deltaTime;
        Vector3 currentPlayerPos = player.transform.position;

        if (Vector3.Distance(transform.position, player.transform.position) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }
}
