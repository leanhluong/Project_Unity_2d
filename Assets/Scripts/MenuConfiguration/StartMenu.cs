using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;
    public Button exitButton;

    private void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(NewGame);
        optionButton.onClick.AddListener(OpenOptionsPanel);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ContinueGame()
    {
        Loader.Instance.ContinueGame();
    }

    private void NewGame()
    {
        Loader.Instance.LoadScene("Game");
    }

    private void OpenOptionsPanel()
    {
        MenuConfiguration.MenuConfiguration.Instance.SetPage(MenuConfiguration.MenuConfiguration.PageType.Option);
    }

    private void ExitGame()
    {
        MenuConfiguration.MenuConfiguration.Instance.ExitGame();
    }

}
