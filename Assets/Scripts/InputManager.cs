using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InGameMenuConfiguration InGameMenuConfiguration;

    private void Update()
    {
        KeyboardInput();
    }

    public void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InGameMenuConfiguration.SetStatusPanel();
        }
    }

    public void CharactorOnMovement()
    {

    }

}