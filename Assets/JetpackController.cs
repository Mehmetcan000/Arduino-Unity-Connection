using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    [SerializeField] private float jetPackForce;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private PotentiometerReader potentiometerReader;
    private int potentioMeterValue;
    private int waterSensorValue;
    private void Update()
    {
        potentioMeterValue = potentiometerReader.GetPotentioMeterValue();
        waterSensorValue = potentiometerReader.GetWaterSensorValue();
    }

    private void FixedUpdate()
    {
        if (potentioMeterValue >=10)
        {
            if (waterSensorValue >=20)
            {
                playerRigidbody.AddForce( jetPackForce * potentioMeterValue* Vector3.up,ForceMode.Force);
            }
            else if ( waterSensorValue<20 && waterSensorValue>15)
            {
                playerRigidbody.AddForce( jetPackForce * 1/2 * potentioMeterValue* Vector3.up,ForceMode.Force);
            }
            else if ( waterSensorValue<15 && waterSensorValue>10)
            {
                playerRigidbody.AddForce( jetPackForce * 1/4 * potentioMeterValue* Vector3.up,ForceMode.Force);
            }
            else if ( waterSensorValue<10 && waterSensorValue>5)
            {
                playerRigidbody.AddForce( jetPackForce * 1/8 * potentioMeterValue* Vector3.up,ForceMode.Force);
            }
        }
    }
    
    
    
}
