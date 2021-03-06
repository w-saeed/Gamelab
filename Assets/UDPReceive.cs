using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client;

    public bool startRecieving = true;
    public bool printToConsole = false;
    private string data;

    public float angle = 0f, distance = 0f, handsopen = 0f;

    public void Start()
    {

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    float[] SeparateData(String data)
    {
        //Debug.Log(data);
        float[] vs = Array.ConvertAll(data.Split(";"), s => float.Parse(s));

        return vs;
    }

    // receive thread
    private void ReceiveData()
    {
       // client = new UdpClient(port);
        client = SingletonUDPClient.GetInstance().Client;

        while (startRecieving)
        {
            Thread.Sleep(10);
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);
                float[] dataValues = SeparateData(data);
                angle = dataValues[0] / 60;
                distance = dataValues[1];

                handsopen = dataValues[2];


                if (printToConsole) { print(data); }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

}
