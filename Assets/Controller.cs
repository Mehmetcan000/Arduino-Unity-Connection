using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;

public class Controller : MonoBehaviour
{
    private Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string inComingMsg = "";
    private static string outGoingMsg = "";


    private static void DataThread()
    {
        sp = new SerialPort("COM3" ,9600);
        sp.Open();
        while (true)
        {
            if (outGoingMsg != "")
            {
                sp.Write(outGoingMsg);
                outGoingMsg = "";
            }

            inComingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }

    void Start()
    {
        IOThread.Start();
    }

    
    void Update()
    {
        if (inComingMsg !="")
        {
            Debug.Log(inComingMsg);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            outGoingMsg = "0";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            outGoingMsg = "1";
        }
       
    }
}
