using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    private GameManager gamemanager_script;
    GameObject time_UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamemanager_script = GameManager.instance;
        time_UI = GameObject.Find("time");
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager_script != null && !gamemanager_script.is_game_continue && time_UI != null)
        {
            time_UI.GetComponent<TextMeshProUGUI>().text = gamemanager_script.delta.ToString("F1") ;

        }
    }

    public void clicked_replay_button()
    {
        SceneManager.LoadScene("GameScene");
    }
}
