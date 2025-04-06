using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartButtonPress()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
    public void ExitButtonPress()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void CreditButtonPress()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
