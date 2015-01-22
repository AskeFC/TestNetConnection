using System;
using System.Text;
using System.Threading;
using System.Net.NetworkInformation;

namespace testInternetConn
{
    class Pinger
    {
        public System.Windows.Controls.TextBox output;
        public Log logStringer;
        public PingOptions options;
        public Ping pingSender;
        public AutoResetEvent waiter;

        private static int timeOut;
        private static int pingAmount;
        private static bool async;
        private static string site;

        private static PingReply reply;
        private static int countDown = 0;
        private static string data = "hejjegertoogtredivebytetekstdata";
        private static byte[] buffer = Encoding.ASCII.GetBytes(data);

        public Pinger(string siteString, int timeOutInt, int pingAmountInt, bool asyncBool)
        {
            site = siteString;
            timeOut = timeOutInt;
            countDown = pingAmount = pingAmountInt;
            async = asyncBool;
        }

        public void Start()
        {
            if (async == true)
            {
                asyncPing();
            }
            else
            {
                syncPing();
            };
        }

        private void syncPing()
        {
            for (int i = 0, iEnd = pingAmount; i < iEnd; ++i)
            {
                try
                {
                    reply = pingSender.Send(site, timeOut, buffer, options);
                }
                catch (PingException e) // exception
                {
                    //prepareTxt(e.Message);
                    //prepareTxt(e.InnerException);

                    writeTxt(site + " : " + e.InnerException.Message.ToString());
                }
                prepareTxt(reply);
                //output.AppendText(makeTxt(reply));
                //if (reply.Status == IPStatus.Success)
                //{
                //    output.AppendText(Log.txt(reply));
                //}
                //else
                //{
                //    output.AppendText(Log.txt(reply.Status));
                //}
            }
        }

        public void asyncPing()
        {
            countDown = Convert.ToInt32(pingAmount);
            pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
            pingSender.SendAsync(site, timeOut, buffer, options, waiter);
        }

        private void prepareTxt(PingReply p)
        {
            string tmp = "";

            if (p != null)
            {
                if (p.Status == IPStatus.Success)
                {
                    tmp = p.Status.ToString() + " pinging " + site + " in " + p.RoundtripTime.ToString() + "ms";
                }
                else
                {
                    tmp = p.Status.ToString() + " pinging " + site;
                }
            }

            writeTxt(tmp + "\n");
        }

        private void prepareTxt(PingCompletedEventArgs e)
        {
            string tmp = "";

            if (e.Cancelled == true)
            {
                tmp = "Ping canceled.";
            }
            else if (e.Error != null)
            {
                tmp = "Ping failed : " + e.Error.Message.ToString();
            }
            else
            {
                tmp = ((e == null) && (e.Reply == null)) ? "" : e.Reply.Status.ToString() + " pinging " + site + " in " + e.Reply.RoundtripTime.ToString() + "ms";
            }

            writeTxt(tmp + "\n");
        }
        private void writeTxt(string str)
        {
            output.AppendText(str);
        }

        public void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {

            if (countDown == 0)
            {
                waiter.WaitOne();
            }
            else
            {
                prepareTxt(e);
                --countDown;
                pingSender.SendAsync(site, timeOut, buffer, options, waiter);
            }

            ((AutoResetEvent)e.UserState).Set();
        }
    }
}
