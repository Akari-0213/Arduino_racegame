using UnityEngine;
using UnityEngine.InputSystem;
using System.IO.Ports;
using System.Collections.Generic;

public class ArduinoConnector : MonoBehaviour
{
    SerialPort serial = new SerialPort("/dev/cu.usbmodem101", 9600);
    public int resist_sensor_value;
    public int press_sensor_value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serial.Open();  
        // serial.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Keyboard.current.aKey.wasPressedThisFrame)
        // {
        //     serial.Write("1");
        // }
        // else if(Keyboard.current.sKey.wasPressedThisFrame)
        // {
        //     serial.Write("0");
        // }

        
        if (serial.IsOpen)
        {
            try
            {
                // Only try to read if the string is valid
                string data = serial.ReadLine();
                string[] str_array = data.Split(',');
                resist_sensor_value = set_sensor_value(str_array[0]);
                press_sensor_value = set_sensor_value(str_array[1]);
            }
            catch (System.TimeoutException)
            {
                // It is normal to time out if Arduino doesn't send data every single frame.
                // Do nothing here to keep the game running smoothly.
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Serial Read Error: " + e.Message);
            }
        }
        
    }

    private void OnApplicationQuit() {
        serial.Close();
    }

    private int set_sensor_value(string str_value)
    {
        int int_value = 0;
        if (!string.IsNullOrEmpty(str_value))
        {
            // .Trim() removes whitespace like \r or \n
            // TryParse returns true if successful, false if it fails (preventing the crash)
            if (int.TryParse(str_value.Trim(), out int result))
            {

                int_value = result;
            }
            else
            {
                // Optional: Log bad data to see what is causing the issue
                // Debug.LogWarning($"Received non-numeric data: '{data}'");
            }
            
        }
        return int_value;
    }
}
