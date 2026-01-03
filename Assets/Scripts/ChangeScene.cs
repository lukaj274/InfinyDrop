using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneToMain()
    {
        SceneManager.LoadScene(1);
    }
}
