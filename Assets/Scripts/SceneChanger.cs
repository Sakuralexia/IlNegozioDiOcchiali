using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public void GoBackToGlassesSelection()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
