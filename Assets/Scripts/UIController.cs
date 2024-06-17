using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    Text txtTime;
    int totalTime = 120;
    float time;

    bool isPause = false;
    bool isGameOver;
    [SerializeField]
    Text txtPause;
    [SerializeField]
    Text txtBorn;
    public int enemyBorn = 0;
    [SerializeField]
    Text txtEnemyDie;
     public int enemyDie = 0;

    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        txtTime.text = "Time: " + totalTime.ToString();
        time = 0;

        UpdateEnemyCountTextDie();
        UpdateEnemyCountText();

        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            totalTime -= 1;
            txtTime.text = "Time: " + totalTime.ToString();
            time = 0;
        }
        if (totalTime == 0)
        {
            Time.timeScale = 0;
        }
        UpdateEnemyCountText();
        UpdateEnemyCountTextDie();

    }

    public void PauseGame()
    {
        if (isPause)
        {
            txtPause.text = "Pause";
            Time.timeScale = 1;
            isPause = false;
        }
        else
        {
            txtPause.text = "Replay";
            Time.timeScale = 0;
            isPause = true;
        }
    }

    public void IncrementEnemyCount()
    {
        enemyBorn++;
        UpdateEnemyCountText();
    }

    // Phương thức này cập nhật UI Text với số lượng kẻ thù hiện tại
    public void UpdateEnemyCountText()
    {
        txtBorn.text = "Enemy Born : " + enemyBorn.ToString();
    }

    public void UpdateEnemyCountTextDie()
    {
        txtEnemyDie.text = "Enemy Die : " + enemyDie.ToString();
    }

    public void IncrementEnemyCountDie()
    {
        enemyDie++;
        UpdateEnemyCountTextDie();
    }

    public void GameOver( )
    {
          gameoverPanel.SetActive(true);
          Time.timeScale = 0;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}