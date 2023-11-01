using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSystem : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
