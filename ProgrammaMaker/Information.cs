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
        public Information(bool success)
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Location = new Point(20, 35);
            label2.Text = "Succes! Uw CSV bestand is nu klaar voor upload.";
            linkLabel1.Visible = false;
        }

        public Information()
        {
            InitializeComponent();
            label1.Visible = true;
            label2.Text = "© 2018";
            label2.Location = new Point(119, 22);
            linkLabel1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://lukehouben.nl/");
        }
    }
}
