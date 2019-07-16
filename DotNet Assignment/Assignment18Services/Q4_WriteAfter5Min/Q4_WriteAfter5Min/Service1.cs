using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q4_WriteAfter5Min
{
    public partial class Service1 : ServiceBase
    {
        FileInfo fObj;
        System.Timers.Timer _timer;
        DateTime _scheduleTime;

        public Service1()
        {
            InitializeComponent();
            fObj = new FileInfo(@"C:\Users\Rohit\Desktop\MyServiceLogFile2.txt");
            _timer = new System.Timers.Timer();
            _scheduleTime = DateTime.Today.AddDays(1).AddHours(7); // Schedule to run once a day at 7:00 a.m.

        }

        protected override void OnStart(string[] args)
        {
            if (!fObj.Exists)
            {
                fObj.Create();
            }

            string buffer = "Service is started at " + DateTime.Now.ToString();
            WriteInFile(buffer);

            _timer.Enabled = true;
            _timer.Interval = _scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);

        }

        protected void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 1. Process Schedule Task
            // ----------------------------------

            string buffer = "Marvellous at " + DateTime.Now.ToString();
            WriteInFile(buffer);

            // 2. If tick for the first time, reset next run to every 24 hours
            if (_timer.Interval != 2 * 60 * 1000)
            {
                _timer.Interval =  2 * 60 * 1000;
            }
        }

        protected override void OnStop()
        {
            string buffer = "Service is stop at " + DateTime.Now.ToString();
            WriteInFile(buffer);
        }

        public void WriteInFile(string str)
        {
            using (StreamWriter sw = fObj.AppendText())
            {
                sw.WriteLine(str);
            }
        }
    }
}
