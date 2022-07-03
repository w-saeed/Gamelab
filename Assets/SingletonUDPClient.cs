using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
public class SingletonUDPClient
{


    public UdpClient Client { get; set; }
    public int port = 5052;
    private static SingletonUDPClient instance;
    private SingletonUDPClient()
    {
        Client = new UdpClient(port);
    }

    public static SingletonUDPClient GetInstance()
    {
        if(instance == null)
        {
            instance = new SingletonUDPClient();
        }
        return instance;
    }

    
}
