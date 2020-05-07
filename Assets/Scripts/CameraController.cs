using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController player;
    Vector3 lastPlayerPos;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPos = player.transform.position;
    }

    private void Update() {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 currentPlayerPos = player.transform.position;
        Vector3 amountToMove = new Vector3(currentPlayerPos.x - lastPlayerPos.x, 0f, currentPlayerPos.z - lastPlayerPos.z);

        transform.position += new Vector3(amountToMove.x, amountToMove.y, amountToMove.z);

        lastPlayerPos = player.transform.position;
    }
}
