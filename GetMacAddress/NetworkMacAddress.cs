using System;
using System.Net;
using System.Net.NetworkInformation;

namespace GetMacAddress
{
    public static class NetworkMacAddress
    {
        // http://www.codeproject.com/KB/IP/host_info_within_network.aspx
        [System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
        static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref int PhyAddrLen);

        /// <summary>
        /// Gets the MAC address (<see cref="PhysicalAddress"/>) associated with the specified IP.
        /// </summary>
        /// <param name="ipAddress">The remote IP address.</param>
        /// <returns>The remote machine's MAC address.</returns>
        public static PhysicalAddress GetMacAddress(IPAddress ipAddress)
        {
            const int MacAddressLength = 6;
            int length = MacAddressLength;
            var macBytes = new byte[MacAddressLength];
            _ = SendARP(BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0), 0, macBytes, ref length);
            return new PhysicalAddress(macBytes);
        }
        public static string InsertString(string macAddress)
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
}