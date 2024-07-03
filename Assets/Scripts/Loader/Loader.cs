using UnityEngine;

public class Loader : MonoBehaviour
{
    //singleton parttern
    public static Loader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void StartNewGame()
    {

    }

    //public void LoadSavedGame(JSONNode args)
    //{

    //}
}
