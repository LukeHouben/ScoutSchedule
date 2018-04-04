﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            addGroupsToList();
            addDaysToList();
        }

        private void addGroupsToList()
        {
            comboBox1.Items.Add("Bevers");
            comboBox1.Items.Add("Welpen");
            comboBox1.Items.Add("Kabouters");
            comboBox1.Items.Add("Verkenners");
            comboBox1.Items.Add("Gidsen");
            comboBox1.Items.Add("Explorers");
            comboBox1.Items.Add("Pivo's");
            comboBox1.Items.Add("Plusscouts Jr");
            comboBox1.Items.Add("Plusscouts Sr");
            comboBox1.Items.Add("Scouting");
            comboBox1.Items.Add("Verhuur");
        }

        private void addDaysToList()
        {
            comboBox2.Items.Add("Maandag");
            comboBox2.Items.Add("Dinsdag");
            comboBox2.Items.Add("Woensdag");
            comboBox2.Items.Add("Donderdag");
            comboBox2.Items.Add("Vrijdag");
            comboBox2.Items.Add("Zaterdag");
            comboBox2.Items.Add("Zondag");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Bevers":
                    enableFields();
                    comboBox2.SelectedItem = "Donderdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 18, 15, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 19, 45, 00);
                    break;
                case "Welpen":
                    enableFields();
                    comboBox2.SelectedItem = "Maandag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 18, 45, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 20, 15, 00);
                    break;
                case "Kabouters":
                    enableFields();
                    comboBox2.SelectedItem = "Dinsdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 18, 30, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 20, 00, 00);
                    break;
                case "Verkenners":
                    enableFields();
                    comboBox2.SelectedItem = "Woensdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 19, 00, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 21, 00, 00);
                    break;
                case "Gidsen":
                    enableFields();
                    comboBox2.SelectedItem = "Vrijdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 19, 30, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 21, 30, 00);
                    break;
                case "Explorers":
                    enableFields();
                    comboBox2.SelectedItem = "Vrijdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 19, 30, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 21, 30, 00);
                    break;
                case "Pivo's":
                    enableFields();
                    comboBox2.SelectedItem = "Vrijdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 19, 30, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 21, 30, 00);
                    break;
                default:
                    comboBox2.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    break;
            }
        }

        private void enableFields()
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        private void disableFields()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            numericUpDown1.Enabled = false;
        }

        private void informatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (checkNoFieldEmpty())
            {
                disableFields();
                button1.Enabled = false;
                int weeks = Decimal.ToInt32(numericUpDown1.Value - 1);
                dataGridView1.Rows.Add(weeks);
                for (int i = 0; i < dataGridView1.Rows.Count; ++ i)
                {
                    dataGridView1[3, i].Value = dateTimePicker1.Value.TimeOfDay;
                    dataGridView1[4, i].Value = dateTimePicker2.Value.TimeOfDay;
                    dataGridView1[5, i].Value = comboBox1.SelectedItem.ToString();
                }
                dataGridView1.Visible = true;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private Boolean checkNoFieldEmpty()
        {
            bool correct = true;
            if (numericUpDown1.Value == 0)
            {
                label5.ForeColor = Color.Red;
                correct = false;
            } else { label5.ForeColor = Color.Black; }

            if (comboBox1.SelectedItem == null || comboBox1.SelectedItem.Equals(""))
            {
                label1.ForeColor = Color.Red;
                correct = false;
            } else { label1.ForeColor = Color.Black; }

            if (comboBox2.SelectedItem == null || comboBox2.SelectedItem.Equals(""))
            {
                label4.ForeColor = Color.Red;
                correct = false;
            } else { label4.ForeColor = Color.Black; }

            return correct;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
