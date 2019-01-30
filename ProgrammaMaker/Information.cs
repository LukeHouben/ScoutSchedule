using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammaMaker
{
    public partial class Information : Form
    {
        public Information(bool success, String message = "")
        {
            InitializeComponent();
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label2.Location = new Point(20, 35);
            textBox1.Visible = false;
            if (success)
            {
                label2.Text = "Succes! Uw CSV bestand is nu klaar voor upload.";
            } else
            {
                label2.Text = "Error: ";
                textBox1.Text = message;
                textBox1.Visible = true;
            }
            linkLabel1.Visible = false;
        }

        public Information(String version)
        {
            InitializeComponent();
            label1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label2.Text = "© 2018-2019";
            label2.Location = new Point(119, 22);
            linkLabel1.Visible = true;
            textBox1.Visible = false;
            label4.Text = version;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://lukehouben.nl/");
        }
    }
}
