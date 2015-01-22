using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace testInternetConn
{
    public static class DnsCheck
    {
        private static string hostName;
        private static IPHostEntry googleHost;

        private static void showErr(string e)
        {
            System.Windows.Forms.MessageBox.Show("There is a problem with DNS resolving : " + e);
        }

        private static bool getHostName()
        {
            try
            {
                hostName = Dns.GetHostName();
                return true;
            }
            catch (SocketException e)
            {
                showErr(e.ToString());
                return false;
                //Console.WriteLine("Source : " + e.Source);
                //Console.WriteLine("Message : " + e.Message);
            }
            catch (Exception e)
            {
                showErr(e.ToString());
                return false;
                //Console.WriteLine("Source : " + e.Source);
                //Console.WriteLine("Message : " + e.Message);
            }
        }

        private static bool getGoogle()
        {
            try
            {
                googleHost = Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (SocketException e)
            {
                showErr(e.ToString());
                return false;
            }
        }
        
        private static bool getMS()
        {
            try
            {
                googleHost = Dns.GetHostEntry("www.microsoft.com");
                return true;
            }
            catch (SocketException e)
            {
                showErr(e.ToString());
                return false;
            }
        }

        private static async Task<bool> getGoogleAS()
        {
            try
            {
                googleHost = await Dns.GetHostEntryAsync("www.google.com");
                return true;
            }
            catch (SocketException e)
            {
                showErr(e.ToString());
                return false;
            }
            // ArgumentNullException  -- The hostNameOrAddress parameter is null.
            // ArgumentOutOfRangeException  -- The length of hostNameOrAddress parameter is greater than 255 characters.
            // ArgumentException  -- The hostNameOrAddress parameter is an invalid IP address.
        }

        public static bool start()
        {
            return (getHostName() && getGoogle() && getMS());
        }
    }
}
