using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace testInternetConn
{
    public static class frameworkCheck
    {
        private static bool isCompliant = false;

        static frameworkCheck()
        {
            if(Type.GetType("System.Runtime.GCLargeObjectHeapCompactionMode", false) != null)
            {
                isCompliant = true;
            };
        }

        public static string GetDefaultBrowserPath()
        {
            string urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\https";
            string browserPathKey = @"$BROWSER$\shell\open\command";
            string browserPath = "";
            string tmpPath = "";
            RegistryKey userChoiceKey = null;

            try
            {
                //Read default browser path from userChoiceLKey
                userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false);

                //If user choice was not found, try machine default
                if (userChoiceKey == null)
                {
                    //Read default browser path from Win XP registry key
                    var browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTPS\shell\open\command", false);

                    //If browser path wasn’t found, try Win Vista (and newer) registry key
                    if (browserKey == null)
                    {
                        browserKey = Registry.CurrentUser.OpenSubKey(urlAssociation, false);
                    };

                    tmpPath = (browserKey.GetValue(null) as string);
                    browserKey.Close();
                }
                else
                {
                    // user defined browser choice was found
                    string progId = (userChoiceKey.GetValue("ProgId").ToString());
                    userChoiceKey.Close();

                    // now look up the path of the executable
                    string concreteBrowserKey = browserPathKey.Replace("$BROWSER$", progId);
                    var kp = Registry.ClassesRoot.OpenSubKey(concreteBrowserKey, false);

                    tmpPath = (kp.GetValue(null) as string);
                    kp.Close();
                };
                
                browserPath = tmpPath.ToLower().Replace("\"", "");
                if (!browserPath.EndsWith("exe"))
                {
                    browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                };
            }
            catch(Exception ex)
            {
                browserPath = string.Empty;
            };
            return browserPath;
        }

        public static bool run()
        {
            if (isCompliant == false)
            { 
                Process.Start(GetDefaultBrowserPath(), "https://www.microsoft.com/en-us/download/details.aspx?id=40773");
            };
            return isCompliant;
        }

    }
}
