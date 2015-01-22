//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace testInternetConn
{
    public static class NetCardCheck
    {
        public static bool IsNetworkAvailable()
        {
            return IsNetworkAvailable(0);
        }

        public static bool IsNetworkAvailable(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            };

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) || (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) || (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                {
                    continue;
                };

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                {
                    continue;
                }

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) || (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    continue;
                }

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                return true;
            };
            return false;
        }
    }
}
