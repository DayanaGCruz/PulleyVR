using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string scene; // Scene to load

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
