using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartButtonPress()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
    public void CreditButtonPress()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
