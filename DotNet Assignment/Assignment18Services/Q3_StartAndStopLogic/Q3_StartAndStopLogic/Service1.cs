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

namespace Q3_StartAndStopLogic
{
    public partial class Service1 : ServiceBase
    {
        FileInfo fObj;

        public Service1()
        {
            InitializeComponent();
            fObj = new FileInfo(@"C:\Users\Rohit\Desktop\MyServiceLogFile.txt");
        }

        protected override void OnStart(string[] args)
        {
            if (!fObj.Exists)
            {
                fObj.Create();
            }

            string buffer = "Service is started at " + DateTime.Now.ToString();
            WriteInFile(buffer);
            
        }

        protected override void OnStop()
        {
            string buffer = "Service is stop at " + DateTime.Now.ToString();
            WriteInFile(buffer);
        }
        
        public void WriteInFile( string str)
        {
            using (StreamWriter sw = fObj.AppendText())
            {
                sw.WriteLine(str);
            }
        }
    }
}
