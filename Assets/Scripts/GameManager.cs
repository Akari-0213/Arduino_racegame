using NUnit.Framework;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;
    GameObject time;
    public float delta = 0;
    public bool is_game_continue;

    void Awake()
    {
        delta = 0;
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    } 
    void Start()
    {
        time = GameObject.Find("Time");
        is_game_continue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_game_continue)
        {
            delta += Time.deltaTime;
            time.GetComponent<TextMeshProUGUI>().text = "Time: " + delta.ToString("F1");
        }
    }
}
