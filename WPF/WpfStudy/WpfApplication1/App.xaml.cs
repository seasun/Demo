using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Helper;

namespace WpfApplication1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            base.Activated += new EventHandler(App_Activated);
        }

        void App_Activated(object sender, EventArgs e)
        {
            "this is activated event!".DebugWrite("Activated Event");
        }
    }
}
