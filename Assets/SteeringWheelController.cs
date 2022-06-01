using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Reflection;
using UnityEditor;

public class SteeringWheelController : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udr;


    void Start()
    {


    }
    // Update is called once per frame\^


    void Update()
    {

        //82.1111
        UDPReceive udp_recieve = GameObject.Find("Client").GetComponent<UDPReceive>();

        float data = udp_recieve.steering * 90f;
        //print(data);
        try
        {
            //Debug.Log(data);
        gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, data);

        }
        catch (FormatException fex)
        {
        //float ft = 71.00f;
        }


    }

}
