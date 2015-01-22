using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Net.NetworkInformation;

using Xceed.Wpf.Toolkit;

namespace testInternetConn
{
    public partial class MainWindow : Window
    {
        private static List<Pinger> pingList = new List<Pinger>();
        private static Thread worker;
        private static bool allGood = false;
        
        private static SolidColorBrush ColorFail = new SolidColorBrush(Colors.Red);
        private static SolidColorBrush ColorWait = new SolidColorBrush(Colors.Yellow);
        private static SolidColorBrush ColorDef = new SolidColorBrush(Colors.Gray);
        private static SolidColorBrush ColorDone = new SolidColorBrush(Colors.Green);
        private static SolidColorBrush ColorBlack = new SolidColorBrush(Colors.Black);

        public MainWindow()
        {
            string tmp = "No network found!";

            if (NetCardCheck.IsNetworkAvailable() == true)
            {
                tmp = "Problem wih DNS!";
                if (DnsCheck.start() == true) {
                    allGood = true;
                    tmp = "Ready";
                };
            };

            InitializeComponent();

            PingStart.IsEnabled = allGood;
            StatusLeft.Text = tmp;
            PingAmount.Value = 3;
        }

        private void WorkThreadFunction()
        {
            try
            {
                this.Dispatcher.Invoke((MethodInvoker)delegate
                {
                    pingList.Add(
                        new Pinger(SiteList.Text, Convert.ToInt32(TimeOut.Value), Convert.ToInt32(PingAmount.Value), Convert.ToBoolean(AsyncPing.IsChecked))
                            {
                                output = TextOutput,
                                logStringer = new Log(Convert.ToBoolean(VerboseOutput.IsChecked)),
                                options = new PingOptions(Convert.ToInt32(Ttl.Value), Convert.ToBoolean(Fragmentation.IsChecked)),
                                waiter = new AutoResetEvent(false),
                                pingSender = new Ping()
                            }
                    );
                    pingList.Last().Start();
                });
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            };
        }

        private void StartPing(object sender, RoutedEventArgs e)
        {
            worker = new Thread(new ThreadStart(WorkThreadFunction));
            worker.Start();
        }

        private void AmountSet(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int tmp = Convert.ToInt32(e.NewValue);

            if (ResultGrid != null)
            {
                ResultGrid.Children.Clear();
                
                for (int i = 0; i < tmp; ++i)
                {
                    Rectangle box = new Rectangle()
                    {
                        RadiusX = 5,
                        RadiusY = 5,
                        Height = 52,
                        VerticalAlignment = System.Windows.VerticalAlignment.Top,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                        Fill = ColorDef,
                        Stroke = ColorBlack,
                        Margin = new Thickness(5,5,5,5),
                        Width = (563 - (tmp * 10)) / tmp
                    };

                    Grid.SetRow(box, 0);
                    Grid.SetColumn(box, i);
                    ResultGrid.Children.Add(box);
                };
            };
        }

        private void scrollToTxt(object sender, TextChangedEventArgs e)
        {
            TextOutput.ScrollToEnd();
        }

        private void LogBoxClear(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextOutput.Text = "";
        }

        private void LogBoxHoverIn(object sender, System.EventArgs e)
        {
            LogBox.Header = LogBox.ToolTip;
        }

        private void LogBoxHoverOut(object sender, System.EventArgs e)
        {
            LogBox.Header = "Log";
        }
    }
}
