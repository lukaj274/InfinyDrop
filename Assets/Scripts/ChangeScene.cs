using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneToMain(int level)
    {
        ScoreManager.ScoreMultiplier = level;
        SceneManager.LoadScene(1);
    }
}
