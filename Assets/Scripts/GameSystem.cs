using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        ConfirmationWindowSystem.Instance.Show("Are you sure you want to return to main menu?", ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
