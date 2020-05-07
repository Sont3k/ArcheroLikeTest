using UnityEngine;
//TODO repalce singleton with FindObjectOfType<Type>()
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake() {
        instance = this;
    }
}
