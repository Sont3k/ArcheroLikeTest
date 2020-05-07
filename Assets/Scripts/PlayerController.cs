using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = .4f;

    public float MovementSpeed { get => movementSpeed; }
}
