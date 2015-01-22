//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;

namespace testInternetConn
{
    public partial class App : Application
    {
        public App()
        {
            if (frameworkCheck.run() == false)
            {
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                };
            };
        }
    }
}
