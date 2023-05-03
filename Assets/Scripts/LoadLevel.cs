using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] string levelName = "Main";
    public void Load()
    {
        SceneManager.LoadScene(levelName);
    }
}
