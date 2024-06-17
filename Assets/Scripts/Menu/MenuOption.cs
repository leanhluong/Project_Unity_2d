using UnityEngine.SceneManagement;
using UnityEngine;

public class Chucnang : MonoBehaviour
{
    public void ChoiMoi()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ThoatRaMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Thoat()
    {

    }
    public void ChonMap()
    {

    }
}
