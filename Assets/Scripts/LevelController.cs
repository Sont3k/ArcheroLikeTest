using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        if (index == 0 || index == 1)
        {
            SceneManager.LoadScene(index);
        }
    }
}
