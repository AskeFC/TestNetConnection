using System.Net.NetworkInformation;

namespace testInternetConn
{
    class Log
    {
        private static bool IsVerbose;

        public Log(bool verbose)
        {
            IsVerbose = verbose;
        }

        public static string txt(string outTxt)
        {
            return outTxt + "\n";
        }
        public static string txt(object outTxt)
        {
            return outTxt.ToString() + " object\n";
        }
        public static string txt(IPStatus outTxt)
        {
            return outTxt.ToString() + " ipstatus\n";
        }
        public static string txt(PingReply outTxt)
        {
            //string tmp = "";
            //if (outTxt != null)
            //{
            //    tmp = ""
            //}
            return (outTxt != null) ? outTxt.Status.ToString() : "";
            //TextOutput.AppendText(status);
            //if (IsVerbose == true)
            //{
            //    TextOutput.AppendText(outTxt + "\n");
            //}
        }
    }
}
