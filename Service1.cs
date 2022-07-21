using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WinSerPicturemix
{
    public partial class Service1 : ServiceBase
    {
        private Timer Timer1;
        public Service1()
        {
            InitializeComponent();
            this.AutoLog = false;
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "My Log");
            }
            eventLog1.Source = "MySource";
        }

        protected override void OnStart(string[] args)
        {
            Timer1 = new Timer();
            Timer1.Elapsed += new ElapsedEventHandler(Timer1Elapsed);
            Timer1.Interval = 10 * 1000;
            Timer1.Start();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stop Timer");
            Timer1.Stop();
            Timer1 = null;
        }

        private void Timer1Elapsed(object sender, ElapsedEventArgs e)
        {
            eventLog1.WriteEntry("Timer Ticked");
        }
    }
}
