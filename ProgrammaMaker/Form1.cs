using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProgrammaMaker
{
    public partial class Form1 : Form
    {
        protected String lastFileSave;

        public Form1()
        {
            InitializeComponent();
            linkLabel1.Visible = false;
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
            comboBox1.Items.Add("Pivo");
            comboBox1.Items.Add("+Scouts jr");
            comboBox1.Items.Add("+Scouts sr");
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableFields();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridView1.RowCount = 0;
            dataGridView1.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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
                case "Pivo":
                    enableFields();
                    comboBox2.SelectedItem = "Vrijdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 19, 30, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 21, 30, 00);
                    break;
                default:
                    comboBox2.SelectedItem = "Zaterdag";
                    dateTimePicker1.Value = new System.DateTime(2000, 01, 01, 12, 00, 00);
                    dateTimePicker2.Value = new System.DateTime(2000, 01, 01, 17, 00, 00);
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
            checkBox1.Enabled = true;
            button1.Enabled = true;
            //button3.Enabled = true;
            //button4.Enabled = true;

        }

        private void disableFields()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            numericUpDown1.Enabled = false;
            checkBox1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
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
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;

                int weeks = Decimal.ToInt32(numericUpDown1.Value);
                if (weeks > 0)
                {
                    dataGridView1.Rows.Add(weeks);
                }
                for (int i = 0; i < dataGridView1.Rows.Count; ++ i)
                {
                    dataGridView1[3, i].Value = dateTimePicker1.Value.TimeOfDay;
                    dataGridView1[4, i].Value = dateTimePicker2.Value.TimeOfDay;
                    dataGridView1[5, i].Value = comboBox1.SelectedItem.ToString();
                }
                if (checkBox1.Checked)
                {
                    calculateDates(true);
                }
                dataGridView1.Visible = true;
            }         
        }


        private void calculateDates(Boolean all)
        { 
            DateTime Today = DateTime.Today;
            DayOfWeek day = Today.DayOfWeek;
            int todayIndex = getDayIndex(day);
            DateTime next = Today;
            if (todayIndex == comboBox2.SelectedIndex)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    next = next.AddDays(7);
                    if (all)
                    {
                        dataGridView1[1, i].Value = next.Date.ToString("d");
                        dataGridView1[2, i].Value = next.Date.ToString("d");
                    }
                    else if (i == dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("d");
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("d");
                    }
                }
            }

            if (todayIndex < comboBox2.SelectedIndex)
            {
                next = next.AddDays(comboBox2.SelectedIndex - todayIndex);
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (all)
                    {
                        dataGridView1[1, i].Value = next.Date.ToString("d");
                        dataGridView1[2, i].Value = next.Date.ToString("d");
                    }
                    else if (i == dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("d");
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("d");
                    }
                    next = next.AddDays(7);
                }
            }

            if (todayIndex > comboBox2.SelectedIndex)
            {
                next = next.AddDays(7 - (todayIndex - comboBox2.SelectedIndex));
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (all)
                    {
                        dataGridView1[1, i].Value = next.Date.ToString("d");
                        dataGridView1[2, i].Value = next.Date.ToString("d");
                    } else if (i == dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("d");
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("d");
                    }
                    next = next.AddDays(7);
                }
            }
        }

        private int getDayIndex(DayOfWeek today)
        {
            switch (today.ToString())
            {
                case "Monday":
                    return 0;
                case "Tuesday":
                    return 1;
                case "Wednesday":
                    return 2;
                case "Thursday":
                    return 3;
                case "Friday":
                    return 4;
                case "Saturday":
                    return 5;
                case "Sunday":
                    return 6;
                default:
                    throw new InvalidDataException("Ongeldige dag in getDayIndex(), laat dit weten aan Luke Houben!");
            }
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

        private void reporteerEenFoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lukkie1998/ScoutSchedule/issues");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = comboBox1.SelectedItem.ToString() + "_" + 
                Decimal.ToInt32(numericUpDown1.Value) + "_weken";
            saveFileDialog1.Filter = "CSV Bestand|*.csv";
            saveFileDialog1.Title = "Sla CSV bestand op als...";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    StreamWriter writer;
                    try { writer = new StreamWriter(saveFileDialog1.OpenFile()); }
                    catch (IOException d) { Console.WriteLine(d); return; }
                    
                    writer.WriteLine("\"Title\",\"Startdate\",\"Enddate\",\"Start\",\"End\",\"Category\"");
                    for (int i = 0; i < dataGridView1.Rows.Count; ++ i)
                    {
                        for (int j = 0; j <= dataGridView1.Columns.Count - 2; ++ j)
                        {
                            try
                            {
                                writer.Write("\"" + dataGridView1[j, i].Value.ToString() + "\",");
                            }
                            catch (NullReferenceException)
                            {
                                writer.Write("\"\",");
                            }
                        }
                        try
                        {
                            writer.WriteLine("\"" + dataGridView1[dataGridView1.Columns.Count - 1, i].Value.ToString() + "\"");
                        }
                        catch (NullReferenceException)
                        {
                            writer.WriteLine("\"\"");
                        }
                    }

                    lastFileSave = saveFileDialog1.FileName;
                    writer.Dispose();
                    writer.Close();
                    setFileLink();
                    Information info = new Information(true);
                    info.ShowDialog();
                }
            }
        }

        private void setFileLink()
        {
            label6.Text = "Laatst opgeslagen: ";
            linkLabel1.Visible = true;
            linkLabel1.Text = lastFileSave;
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.scoutingstein.nl/wp-admin/edit.php?post_type=tribe_events&page=aggregator");
        }

        private void mailProgrammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String speltak = "";
            try
            {
                speltak = comboBox1.SelectedItem.ToString();
            } catch
            {
                checkNoFieldEmpty();
                return;
            }
            
            String[] emails = new String[4] { "luuk@vanmeulenbroek.nl", "arno.deblaauw@gmail.com", "a.deblaauw@grotius-lvo.nl", "rpj.ensing@gmail.com" };
            String URI;
            String protocol = "mailto:";

            URI = generateURI(emails, speltak, protocol);
            System.Diagnostics.Process.Start(URI);
        }

        private String generateURI(String[] emails, String speltak, String protocol)
        {
            String URI = protocol;
            foreach(String email in emails) {
                URI += email + ';';
            }

            URI += "?subject=Programma " + speltak ;
            URI += "&body=Hallo, %0ADeze email bevat het programma van Speltak: " + speltak + ". %0A%0AMet vriendelijke groet, %0A" + speltak;

            return URI;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lastFileSave);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(1);
            numericUpDown1.Value++;
            if (checkBox1.Checked)
            {
                calculateNewDates();
            }
            if (dataGridView1.RowCount > 0)
            {
                button4.Enabled = true;
            }
        }

        public void calculateNewDates()
        {
            dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dateTimePicker1.Value.TimeOfDay;
            dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dateTimePicker2.Value.TimeOfDay;
            dataGridView1[5, dataGridView1.Rows.Count - 1].Value = comboBox1.SelectedItem.ToString();
            calculateDates(false);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.RowCount = dataGridView1.Rows.Count - 1;
            numericUpDown1.Value--;
            if (dataGridView1.RowCount == 0)
            {
                button4.Enabled = false;
            }
        }
    }
}
