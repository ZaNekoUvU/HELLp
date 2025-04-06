using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    public void MenuButtonPress()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


}
