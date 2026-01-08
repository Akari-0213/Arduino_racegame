using UnityEngine;

public class test : MonoBehaviour
{
    float a = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Debug.Log(a);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(a, 0, 0);
    }
}
