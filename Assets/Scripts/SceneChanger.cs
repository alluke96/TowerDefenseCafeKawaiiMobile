using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //-----------------------------------------------------------------------------------------------------------------
    // Public methods
    //-----------------------------------------------------------------------------------------------------------------
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}