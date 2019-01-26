using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ProgrammaMaker
{
    public partial class Form1 : Form
    {
        protected String lastFileSave;
        protected String version = "1.0.2";

        public Form1()
        {
            InitializeComponent();
            linkLabel1.Visible = false;
            dataGridView1.Visible = false;
            addGroupsToList();
            addDaysToList();
            checkForUpdate();
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
            mailProgrammaToolStripMenuItem.Enabled = false;

            dataGridView1.RowCount = 0;
            dataGridView1.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Bestand | *.csv";
            openFileDialog1.Title = "Selecteer het CSV bestand...";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.               
                newToolStripMenuItem_Click(sender, e);
                StreamReader file = new StreamReader(openFileDialog1.FileName);
                String line = file.ReadLine();
                int count = 0;
                while ((line = file.ReadLine()) != null)
                {
                    String[] activities = line.Trim('"').Split(new String[] { "\",\"" }, StringSplitOptions.None);
                    dataGridView1.Rows.Add(1);
                    count++;
                    for (int i = 0; i < activities.Length; i++)
                    {
                        dataGridView1[i, dataGridView1.Rows.Count - 1].Value = activities[i];
                    }
                }
                comboBox1.SelectedItem = dataGridView1[dataGridView1.Columns.Count - 1, dataGridView1.Rows.Count - 1].Value;
                //System.Console.WriteLine(dataGridView1[dataGridView1.Columns.Count - 1, dataGridView1.Rows.Count - 1].Value);
                //comboBox1_SelectedIndexChanged(sender, e);
                numericUpDown1.Value = count;
                disableFields();
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                mailProgrammaToolStripMenuItem.Enabled = true;
                checkBox1.Checked = true;
                dataGridView1.Visible = true;
                file.Close();
            }
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
                mailProgrammaToolStripMenuItem.Enabled = true;

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
                        dataGridView1[1, i].Value = next.Date.ToString("dd-MM-yyyy");
                        dataGridView1[2, i].Value = next.Date.ToString("dd-MM-yyyy");
                    }
                    else if (i == dataGridView1.Rows.Count - 1)
                    {
                        if (dataGridView1.Rows.Count != 0)
                        {
                            next = DateTime.ParseExact(dataGridView1[1, dataGridView1.Rows.Count - 2].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddDays(7);
                        }

                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("dd-MM-yyyy");
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("dd-MM-yyyy");
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
                        dataGridView1[1, i].Value = next.Date.ToString("dd-MM-yyyy");
                        dataGridView1[2, i].Value = next.Date.ToString("dd-MM-yyyy");
                    }
                    else if (i == dataGridView1.Rows.Count - 1)
                    {
                        next = DateTime.ParseExact(dataGridView1[1, dataGridView1.Rows.Count - 2].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddDays(7);

                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("dd-MM-yyyy");
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("dd-MM-yyyy");
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
                        dataGridView1[1, i].Value = next.Date.ToString("dd-MM-yyyy");
                        dataGridView1[2, i].Value = next.Date.ToString("dd-MM-yyyy");
                    }
                    else if (i == dataGridView1.Rows.Count - 1)
                    {
                        if (dataGridView1.Rows.Count >= 2)
                            next = DateTime.ParseExact(dataGridView1[1, dataGridView1.Rows.Count - 2].Value.ToString(), "dd-MM-yyyy", CultureInfo.CurrentCulture).AddDays(7);

                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("dd-MM-yyyy");
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = next.Date.ToString("dd-MM-yyyy");
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
                    catch (IOException d)
                    {
                        Information infoWrong = new Information(false, d.Message);
                        infoWrong.ShowDialog();
                        return;
                    }
                    
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
                if (dataGridView1.RowCount == 0)
                {
                    return;
                }
            } catch
            {
                checkNoFieldEmpty();
                return;
            }
            
            String[] emails = new String[2] { "rpj.ensing@gmail.com", "luuk@vanmeulenbroek.nl" };
            String URI;
            String protocol = "mailto:";

            URI = generateURI(emails, speltak, protocol);
            System.Diagnostics.Process.Start(URI);
        }

        private String getStartEndData()
        {
            String firstDate = dataGridView1[1, 0].Value.ToString();
            String lastDate = dataGridView1[2, dataGridView1.RowCount - 1].Value.ToString();
            return firstDate + " t/m " + lastDate;
            
        }

        private List<String> getProgramData()
        {
            List<String> result = new List<String>();
            String tmp = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                try
                {
                    tmp = dataGridView1[1, i].Value.ToString() + " " + dataGridView1[3, i].Value.ToString() + " - " +
                        dataGridView1[2, i].Value.ToString() + " " + dataGridView1[4, i].Value.ToString() + ": " +
                        dataGridView1[0, i].Value.ToString() + "%0A";
                }
                catch (NullReferenceException e)
                {
                    Information dialog = new Information(false, "Er is een fout opgetreden. Kijk nogmaals of alle velden zijn ingevuld en probeer opnieuw.");
                    dialog.ShowDialog();
                    result.Add("Deze data kon niet worden geformatteerd. %0A");
                    return result;
                }

                result.Add(tmp);
            }

            return result;
        }

        private String generateURI(String[] emails, String speltak, String protocol)
        {
            List<String> result = getProgramData();
            String URI = protocol;
            foreach(String email in emails) {
                URI += email + ';';
            }

            URI += "?subject=Programma " + speltak + " " + getStartEndData();
            URI += "&body=Hallo, %0ADeze email bevat het programma van Speltak: " + speltak + ". %0A %0A";

            foreach(String line in result) {
                URI += line;
            }

            URI += "%0AMet vriendelijke groet, %0A" + speltak;

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

            dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dateTimePicker1.Value.TimeOfDay;
            dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dateTimePicker2.Value.TimeOfDay;
            dataGridView1[5, dataGridView1.Rows.Count - 1].Value = comboBox1.SelectedItem.ToString();

            if (checkBox1.Checked)
            {
                calculateDates(false);
            }

            if (dataGridView1.RowCount > 0)
            {
                button4.Enabled = true;
                mailProgrammaToolStripMenuItem.Enabled = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.RowCount = dataGridView1.Rows.Count - 1;
            numericUpDown1.Value--;

            if (dataGridView1.RowCount == 1)
            {
                button4.Enabled = false;
            }
        }

        private void checkForUpdate()
        {
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("User-Agent: Other");
                string webData = wc.DownloadString("https://lukehouben.nl/shared/appVersion.txt");
                if (!webData.Equals(version))
                {
                    Information updateAvailable = new Information(false, "Er is een update beschikbaar! Download de laatste versie nu!");
                    updateAvailable.ShowDialog();
                }
            } catch
            {
                
            }

            
        }
    }
}
