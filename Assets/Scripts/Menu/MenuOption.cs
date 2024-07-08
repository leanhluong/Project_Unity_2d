using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    public void ChoiMoi()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ThoatRaMenu()
    {
        SceneManager.LoadScene(0);
    }
}
