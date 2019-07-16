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

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        FileInfo fObj;
        System.Timers.Timer timer;
       

        public Service1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();

        }

        protected override void OnStart(string[] args)
        {
            string dt = DateTime.Now.ToString("dd-MM-yyyy");
            string filename = $@"C:\Users\Rohit\Desktop\ServicesLogFile{dt}.txt";
            fObj = new FileInfo(filename);
            if (!fObj.Exists)
            {
                fObj.Create();
            }

            string buffer = "Service is started at " + DateTime.Now.ToString();
            WriteInFile(buffer);

            
                timer.Enabled = true;
                timer.Interval = 2 * 60 * 1000;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            //    _timer.Start();
            

        }

        protected void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string buffer = "Marvellous at " + DateTime.Now.ToString();
            WriteInFile(buffer);
            
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
