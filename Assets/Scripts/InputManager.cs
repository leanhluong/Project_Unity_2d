using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InGameMenuConfiguration InGameMenuConfiguration;
    public GameObject player;

    public static InputManager Instance;

    public enum State
    {
        InMenu,
        Play,
    }

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
    }

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


}