using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuConfiguration : MonoBehaviour
{
    [Header("Buttons")]
    public Button continueButton;
    public Button mapButton;
    public Button inventoryButton;
    public Button settingsButton;
    public Button exitButton;

    private bool isOn = false;

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    public void SetStatusPanel()
    {
        gameObject.SetActive(!isOn);
        isOn = !isOn;
    }

    private void OnContinueButtonClick()
    {
        SetStatusPanel();
    }

    private void OnExitButtonClick()
    {
        continueButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        Loader.Instance.SaveToJson();
        Loader.Instance.LoadScene("Menu");
    }


}
