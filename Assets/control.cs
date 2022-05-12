using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Reflection;
using UnityEditor;

public class control : MonoBehaviour
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
        string data = udr.data;
        print(data);

        float ft = float.Parse(data);

        //float ft = 71.00f;

        transform.localEulerAngles = new Vector3(0, 0, ft);



    }

}
