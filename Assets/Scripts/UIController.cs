using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    PlayerController player;
    [SerializeField] Sprite heart1, heart2, heart3;
    [SerializeField] Sprite heartFull, heartHalf, heartEmpty;

    public void UpdateHealthDisplay()
    {
        switch (player.Health)
        {
            case 3:
                heart1 = heartFull;
                heart2 = heartHalf;
                heart3 = heartEmpty;

                break;
            case 2:
                heart1 = heartFull;
                heart2 = heartEmpty;
                heart3 = heartEmpty;

                break;
            case 1:
                heart1 = heartHalf;
                heart2 = heartEmpty;
                heart3 = heartEmpty;

                break;
            case 0:
                heart1 = heartEmpty;
                heart2 = heartEmpty;
                heart3 = heartEmpty;

                break;
            default:
                heart1 = heartEmpty;
                heart2 = heartEmpty;
                heart3 = heartEmpty;

                break;
        }
    }
}