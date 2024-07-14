using SimpleJSON;
using System.Collections;
using System.IO;
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

    public void SaveToJson()
    {
        float health = InputManager.Instance.player.GetComponent<PlayerController>().currentHealth;
        Vector3 pos = InputManager.Instance.player.transform.position;
        JSONObject json = new JSONObject();
        json.Add("health", health);
        json.Add("posx", pos.x);
        json.Add("posy", pos.y);
        json.Add("posz", pos.z);
        
        string paht = Application.persistentDataPath + "/save.json";
        File.WriteAllText(paht, json.ToString());
    }

    public GameData LoadFromJson()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
        JSONNode data = JSON.Parse(json);
        GameData gameData = new GameData()
        {
            health = data["health"].AsFloat,
            posx = data["posx"].AsFloat,
            posy = data["posy"].AsFloat,
            posz = data["posz"].AsFloat,
        };
        return gameData;
    }

    public void ContinueGame()
    {
        StartCoroutine(LoadGameCoroutine());

    }

    private IEnumerator LoadGameCoroutine()
    {
        var gameData = LoadFromJson();
        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game");
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        while (InputManager.Instance == null)
        {
            yield return null;
        }

        while (InputManager.Instance.player == null)
        {
            yield return null;
        }
        PlayerController playerController = InputManager.Instance.player.GetComponent<PlayerController>();
        playerController.currentHealth = gameData.health;
        playerController.UpdateHealthBar();
        InputManager.Instance.player.transform.position = new Vector3(gameData.posx, gameData.posy, gameData.posz);
    }
}
