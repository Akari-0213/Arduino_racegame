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
    private float start_time;

    void Awake()
    {   
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    } 
    void Start()
    {
        start_time = Time.time;
        time = GameObject.Find("Time");
        instance.is_game_continue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.is_game_continue)
        {
            instance.delta = Time.time - start_time;
            time.GetComponent<TextMeshProUGUI>().text = "Time: " + instance.delta.ToString("F1");
        }
    }
}
