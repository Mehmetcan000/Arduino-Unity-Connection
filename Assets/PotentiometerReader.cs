using System;
using UnityEngine;
using System.IO.Ports;

public class PotentiometerReader : MonoBehaviour {

    private SerialPort serialPort;
    private string incomingData;
    private int[] sensorValues = new int[2]; // Dizide 1.eleman potansiyometre değeri,Dizide 2.eleman su seviyesi değeri.
    
    
    
    void Start() {
        serialPort = new SerialPort("COM3", 9600); // Arduino'nun bağlı olduğu portu belirt
        serialPort.Open();
    }

    void Update() {
        if (serialPort.IsOpen) {
           
                incomingData = serialPort.ReadExisting(); // Seri porttan gelen veriyi oku

                incomingData = incomingData.Trim();
                string[] values = incomingData.Split(',');
                
                    try
                    {
                        if (values.Length >= 2)
                        {
                            if (int.TryParse(values[0], out sensorValues[0]) && int.TryParse(values[1], out sensorValues[1]))
                            {
                                Debug.Log("Potansiyometre Değeri :" + sensorValues[0]);
                                Debug.Log("Su Sensörü Değeri :" + sensorValues[1]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError("Bir hata oluştu: " + ex.Message);
                    }
            
        }
    }

    void OnDestroy() {
        if (serialPort != null && serialPort.IsOpen) {
            serialPort.Close(); // Oyun sona erdiğinde seri portu kapat
        }
    }


    public int GetPotentioMeterValue()
    {
        return sensorValues[0];
    }

    public int GetWaterSensorValue()
    {
        return sensorValues[1];
    }
}

