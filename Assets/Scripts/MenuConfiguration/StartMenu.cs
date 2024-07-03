using MenuConfiguration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button continueButton;
    public Button newGameButton;
    public Button loadGameButton;
    public Button optionButton;
    public Button exitButton;

    private void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(NewGame);
        loadGameButton.onClick.AddListener(OpenLoadGamePanel);
        optionButton.onClick.AddListener(OpenOptionsPanel);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ContinueGame()
    {

    }

    private void NewGame()
    {
        Loader.Instance.LoadScene("Game");
    }

    private void OpenLoadGamePanel()
    {
        MenuControl.Instance.SetPage(MenuControl.PageType.SaveGame);
    }

    private void OpenOptionsPanel()
    {
        MenuControl.Instance.SetPage(MenuControl.PageType.Option);
    }

    private void ExitGame()
    {
        MenuControl.Instance.ExitGame();
    }
}
