using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialManager : MonoBehaviour
{
    public SerialHandler serialHandler;


    //受信用変数
    public float data;              //受信データのfloat型版変数
    string receive_data;            //受信した生データを入れる変数

    //送信用変数
    bool onoff = false;              //オンオフどちらにするかを決定する変数（今回はオンで固定）
    bool cansend = true;            //送信するかどうかを判断する変数
    

    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    //データを受信したら
    void OnDataReceived(string message)
    {
        receive_data = (message);           //受信データをreceive_dataに入れる
        data = float.Parse(receive_data);   //float型に変換してdataに入れる
        Debug.Log("受信データ: " + data);
    }

private void Update()
    {
        // --- ここを追加 ---
        // Aキーを押したらONモードへ
        if (Input.GetKeyDown(KeyCode.A))
        {
            onoff = true;
        }
        // Sキーを押したらOFFモードへ
        if (Input.GetKeyDown(KeyCode.S))
        {
            onoff = false;
        }
        // ----------------

        if (onoff)
        {
            usendmsg(); // オン用
        }
        else
        {
            dsendmsg(); // オフ用
        }
    }

    //オン用メソッド
    void usendmsg()
    {
        if (cansend == true)            //送信可能かチェック
        {
            serialHandler.Write("1");   //Arduinoに1を送信
            Debug.Log("1を送信");
            cansend = false;            //オフになるまで送信不可に設定
        }
    }

    //オフ用メソッド
    void dsendmsg()
    {
        if (cansend == false)           //送信可能かチェック
        {
            serialHandler.Write("0");   //Arduinoに0を送信
            Debug.Log("0を送信");
            cansend = true;             //オフになるまで送信不可に設定
        }
    }
}
