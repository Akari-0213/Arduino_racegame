using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class car : MonoBehaviour
{
    private ArduinoConnector arduinoConnector;
    private float speed = 0.0f;
    private float resist_value = 0.0f;
    private float rot_y_axis = 0.0f;
    private GameManager gamemanager_script;

    Vector3 player_position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamemanager_script = GameManager.instance;
        arduinoConnector = GameObject.Find("Serial").GetComponent<ArduinoConnector>();
        player_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        resist_value = arduinoConnector.resist_sensor_value/1023.0f * 360.0f;
        if(resist_value != 0.0f){
        rot_y_axis = 180.0f - resist_value;
        transform.rotation = Quaternion.Euler(0, rot_y_axis, 0);
        translate_player(rot_y_axis);
        }
        Debug.Log(rot_y_axis);
        
    }

    

    void translate_player(float rot_y_axis)
    {
        if (arduinoConnector.press_sensor_value >= 800)
        {
            speed = arduinoConnector.press_sensor_value * 0.005f;
        }
        else
        {
            speed = arduinoConnector.press_sensor_value * 0.0005f;
        }
        float z_vector = (float) Math.Cos(rot_y_axis * (Math.PI / 180.0f));
        float x_vector = (float) Math.Sin(rot_y_axis * (Math.PI / 180.0f));

        player_position.x += x_vector * speed;
        player_position.z += z_vector * speed;
        transform.position = player_position;    
    }

    void OnTriggerEnter(Collider other)
    {
        gamemanager_script.is_game_continue = false;
        SceneManager.LoadScene("ScoreScene");
    }
}
