using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigator : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] private Button navigator;

    private void Awake() => navigator.onClick.AddListener(() => SceneManager.LoadScene(targetScene));
}
