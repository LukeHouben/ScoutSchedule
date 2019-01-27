using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoutSchedule
{
    public partial class Update : Form
    {
        public Update(String oldVersion, String newVersion)
        {
            InitializeComponent();
            label3.Text = oldVersion;
            label5.Text = newVersion;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String URI = "https://github.com/Lukkie1998/ScoutSchedule/releases/download/v" + label5.Text + "/ScoutSchedule.exe";

            using (var client = new WebClient())
            {
                try
                {
                    //Download the file
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    client.Headers.Add("User-Agent: Other");
                    client.DownloadFile(URI, "ScoutScheduleUpdated.exe");

                    String exePath = Application.ExecutablePath;
                     
                    File.Move(exePath, exePath + ".bak");
                    File.Move(Application.StartupPath + "/ScoutScheduleUpdated.exe", exePath);

                    Application.Restart();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
