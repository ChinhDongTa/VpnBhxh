// See https://aka.ms/new-console-template for more information
using System.Net;

Console.WriteLine("Hello fen!");
var host = Dns.GetHostAddresses(Dns.GetHostName());
foreach (var item in host)
{
    Console.WriteLine("Ip: {0}", item.ToString());
}

Console.WriteLine("Mac Address:{0}", Common.InsertString(NetworkTool.NetworkMacAddress.GetMacAddress(host[1]).ToString()));
Console.ReadLine();

public static class Common
{
    internal static string? InsertString(string macAddress)
    {
        int next = 2;
        int count = macAddress.Length / 2;//số lẻ là sai MacAddress 
        for (int i = 1; i < count; i++)
        {

            macAddress = macAddress.Insert(next, "-");
            next += 3;
        }
        return macAddress;
    }
}
