using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver( )
    {
        SceneManager.LoadScene("GameOver");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}