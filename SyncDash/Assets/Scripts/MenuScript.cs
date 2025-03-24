using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;
    [SerializeField] private GameObject menuSet;
    [SerializeField] private GameObject scoreSet;
    [SerializeField] private GameObject gameOverSet;
    [SerializeField] private MultiplayerManager multiplayerManager;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        int retryCheck = PlayerPrefs.GetInt("ReloadGame", 0);
        if(retryCheck == 1)
        {
            PlayerPrefs.SetInt("ReloadGame", 0);
            PlayClick();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        menuSet.SetActive(false);
        scoreSet.SetActive(true);
        multiplayerManager.GameBegin();
    }

    public void ExitClick()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void RetryClick()
    {
        PlayerPrefs.SetInt("ReloadGame", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }
}
