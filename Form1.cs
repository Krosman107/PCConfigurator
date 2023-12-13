using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        int idcpu;
        int[] arr2 = new int[1];
        int[] arr = new int[1];

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source=database.db; Version=3");
            DB.Open();
            LoadComboBoxData();
        }
        private void LoadComboBoxData()
        {
            SQLiteCommand cmd1 = new SQLiteCommand("SELECT name FROM cpu", DB);
            SQLiteDataReader SQL1 = cmd1.ExecuteReader();
            while (SQL1.Read())
            {
                comboBox1.Items.Add((string)SQL1["name"]);
            }

            SQLiteCommand cmd3 = new SQLiteCommand("SELECT name FROM motherboard", DB);
            SQLiteDataReader SQL3 = cmd3.ExecuteReader();
            while (SQL3.Read())
            {
                comboBox3.Items.Add((string)SQL3["name"]);
            }

            SQLiteCommand cmd5 = new SQLiteCommand("SELECT name FROM cooler", DB);
            SQLiteDataReader SQL5 = cmd5.ExecuteReader();
            while (SQL5.Read())
            {
                comboBox5.Items.Add((string)SQL5["name"]);
            }

            SQLiteCommand cmd7 = new SQLiteCommand("SELECT name FROM gpu", DB);
            SQLiteDataReader SQL7 = cmd7.ExecuteReader();
            while (SQL7.Read())
            {
                comboBox7.Items.Add((string)SQL7["name"]);
            }

            SQLiteCommand cmd9 = new SQLiteCommand("SELECT name FROM ram", DB);
            SQLiteDataReader SQL9 = cmd9.ExecuteReader();
            while (SQL9.Read())
            {
                comboBox9.Items.Add((string)SQL9["name"]);
            }

            SQLiteCommand cmd11 = new SQLiteCommand("SELECT name FROM Hard", DB);
            SQLiteDataReader SQL11 = cmd11.ExecuteReader();
            while (SQL11.Read())
            {
                comboBox11.Items.Add((string)SQL11["name"]);
            }

            SQLiteCommand cmd13 = new SQLiteCommand("SELECT name FROM ssd", DB);
            SQLiteDataReader SQL13 = cmd13.ExecuteReader();
            while (SQL13.Read())
            {
                comboBox13.Items.Add((string)SQL13["name"]);
            }

            SQLiteCommand cmd15 = new SQLiteCommand("SELECT name FROM PowerSupply", DB);
            SQLiteDataReader SQL15 = cmd15.ExecuteReader();
            while (SQL15.Read())
            {
                comboBox15.Items.Add((string)SQL15["name"]);
            }

            SQLiteCommand cmd17 = new SQLiteCommand("SELECT name FROM pc_case", DB);
            SQLiteDataReader SQL17 = cmd17.ExecuteReader();
            while (SQL17.Read())
            {
                comboBox17.Items.Add((string)SQL17["name"]);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox20.Text = string.Empty;
            string selectedComponentName = comboBox1.Text;

            SQLiteCommand CMD1 = new SQLiteCommand("SELECT * FROM cpu WHERE name = @cb1", DB);
            CMD1.Parameters.Add("@cb1", DbType.String).Value = selectedComponentName;
            SQLiteDataReader SQL1 = CMD1.ExecuteReader();
            while (SQL1.Read())
            {
                textBox1.Text += SQL1["price"];
                textBox2.Text += SQL1["info"];
                idcpu = Convert.ToInt32(SQL1["id"]);
                arr2[0] = Convert.ToInt32(SQL1["top"]);
                textBox20.Text += SQL1["top"];
            }
            arr[0] = Convert.ToInt32(textBox1.Text);

            comboBox3.Items.Clear();
            comboBox3.ResetText();
            SQLiteCommand CMD2 = new SQLiteCommand("SELECT m.id, m.name FROM cpu_motherboard cm INNER JOIN motherboard m ON cm.id_motherboard = m.id WHERE cm.id_cpu = @pcbs1", DB);
            CMD2.Parameters.Add("@pcbs1", DbType.Int32).Value = idcpu;
            SQLiteDataReader SQL2 = CMD2.ExecuteReader();
            while (SQL2.Read())
            {
                comboBox3.Items.Add((string)SQL2["name"]);
            }

            textBox3.Clear();
            textBox4.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            string selectedComponentName = comboBox3.Text;

            SQLiteCommand CMD2 = new SQLiteCommand("SELECT * FROM motherboard WHERE name = @cb2", DB);
            CMD2.Parameters.Add("@cb2", DbType.String).Value = selectedComponentName;
            SQLiteDataReader SQL2 = CMD2.ExecuteReader();
            while (SQL2.Read())
            {
                textBox3.Text += SQL2["price"];
                textBox4.Text += SQL2["info"];
                idcpu = Convert.ToInt32(SQL2["id"]);
                arr2[0] = Convert.ToInt32(SQL2["top"]);
            }
            arr[0] = Convert.ToInt32(textBox3.Text);
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            var CMD3 = new SQLiteCommand("select * from cooler where name=@cb3", DB);
            CMD3.Parameters.Add("@cb3", DbType.String).Value = comboBox5.Text;
            var SQL3 = CMD3.ExecuteReader();
            while (SQL3.Read())
            {
                textBox5.Text += SQL3["price"];
                textBox6.Text += SQL3["info"];
                idcpu = Convert.ToInt32(SQL3["id"]);
                arr2[0] = Convert.ToInt32(SQL3["top"]);
            }
            arr[0] = Convert.ToInt32(textBox5.Text);
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox21.Text = string.Empty;
            var CMD4 = new SQLiteCommand("select * from GPU where name=@cb4", DB);
            CMD4.Parameters.Add("@cb4", DbType.String).Value = comboBox7.Text;
            var SQL4 = CMD4.ExecuteReader();
            while (SQL4.Read())
            {
                textBox7.Text += SQL4["price"];
                textBox8.Text += SQL4["info"];
                idcpu = Convert.ToInt32(SQL4["id"]);
                arr2[0] = Convert.ToInt32(SQL4["top"]);
                textBox21.Text += SQL4["top"];
            }
            arr[0] = Convert.ToInt32(textBox7.Text);
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox10.Clear();
            var CMD5 = new SQLiteCommand("select * from RAM where name=@cb5", DB);
            CMD5.Parameters.Add("@cb5", DbType.String).Value = comboBox9.Text;
            var SQL5 = CMD5.ExecuteReader();
            while (SQL5.Read())
            {
                textBox9.Text += SQL5["price"];
                textBox10.Text += SQL5["info"];
                idcpu = Convert.ToInt32(SQL5["id"]);
                arr2[0] = Convert.ToInt32(SQL5["top"]);
            }
            arr[0] = Convert.ToInt32(textBox9.Text);
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox12.Clear();
            textBox22.Text = string.Empty;
            var CMD6 = new SQLiteCommand("select * from Hard where name=@cb6", DB);
            CMD6.Parameters.Add("@cb6", DbType.String).Value = comboBox11.Text;
            var SQL6 = CMD6.ExecuteReader();
            while (SQL6.Read())
            {
                textBox11.Text += SQL6["price"];
                textBox12.Text += SQL6["info"];
                idcpu = Convert.ToInt32(SQL6["id"]);
                arr2[0] = Convert.ToInt32(SQL6["top"]);
                textBox22.Text += SQL6["top"];
            }
            arr[0] = Convert.ToInt32(textBox11.Text);
        }
        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox13.Clear();
            textBox14.Clear();
            textBox23.Text = string.Empty;
            var CMD7 = new SQLiteCommand("select * from SSD where name=@cb7", DB);
            CMD7.Parameters.Add("@cb7", DbType.String).Value = comboBox13.Text;
            var SQL7 = CMD7.ExecuteReader();
            while (SQL7.Read())
            {
                textBox13.Text += SQL7["price"];
                textBox14.Text += SQL7["info"];
                idcpu = Convert.ToInt32(SQL7["id"]);
                arr2[0] = Convert.ToInt32(SQL7["top"]);
                textBox23.Text += SQL7["top"];
            }
            arr[0] = Convert.ToInt32(textBox13.Text);
        }
        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox15.Clear();
            textBox16.Clear();
            var CMD8 = new SQLiteCommand("select * from PowerSupply where name=@cb8", DB);
            CMD8.Parameters.Add("@cb8", DbType.String).Value = comboBox15.Text;
            var SQL8 = CMD8.ExecuteReader();
            while (SQL8.Read())
            {
                textBox15.Text += SQL8["price"];
                textBox16.Text += SQL8["info"];
                idcpu = Convert.ToInt32(SQL8["id"]);
                arr2[0] = Convert.ToInt32(SQL8["top"]);
            }
            arr[0] = Convert.ToInt32(textBox15.Text);
        }
        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Clear();
            textBox18.Clear();
            var CMD9 = new SQLiteCommand("select * from pc_case where name=@cb9", DB);
            CMD9.Parameters.Add("@cb9", DbType.String).Value = comboBox17.Text;
            var SQL9 = CMD9.ExecuteReader();
            while (SQL9.Read())
            {
                textBox17.Text += SQL9["price"];
                textBox18.Text += SQL9["info"];
                idcpu = Convert.ToInt32(SQL9["id"]);
                arr2[0] = Convert.ToInt32(SQL9["top"]);
            }
            arr[0] = Convert.ToInt32(textBox17.Text);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { textBox20, textBox21, textBox22, textBox23 };

            int minValue = int.MaxValue;
            foreach (var textBox in textBoxes)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    int value;
                    if (int.TryParse(textBox.Text, out value))
                    {
                        minValue = Math.Min(minValue, value);
                    }
                }
            }


            textBox24.Text = minValue == int.MaxValue ? string.Empty : minValue.ToString();

            TextBox[] textBoxes1 = { textBox1, textBox3, textBox5, textBox7, textBox9, textBox11, textBox13, textBox15, textBox17 };

            double sum = 0d;
            foreach (var textBox in textBoxes1)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    if (int.TryParse(textBox.Text,  out var value))
                    {
                        sum += value;
                    }
                }
            }

            textBox19.Text = sum + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearComboBox();
        }

        private void ClearComboBox()
        {
            // Очистка отображаемого текста в ComboBox
            comboBox1.ResetText();
            comboBox3.ResetText();
            comboBox5.ResetText();
            comboBox7.ResetText();
            comboBox9.ResetText();
            comboBox11.ResetText();
            comboBox13.ResetText();
            comboBox15.ResetText();
            comboBox17.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей перед выбором компонентов
            ClearComboBox();

            // Выбор первого элемента в comboBox1
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox3
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox5
            if (comboBox5.Items.Count > 0)
            {
                comboBox5.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox7
            if (comboBox7.Items.Count > 0)
            {
                comboBox7.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox9
            if (comboBox9.Items.Count > 0)
            {
                comboBox9.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox11
            if (comboBox11.Items.Count > 0)
            {
                comboBox11.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox13
            if (comboBox13.Items.Count > 0)
            {
                comboBox13.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox15
            if (comboBox15.Items.Count > 0)
            {
                comboBox15.SelectedIndex = 0;
            }

            // Выбор первого элемента в comboBox17
            if (comboBox17.Items.Count > 0)
            {
                comboBox17.SelectedIndex = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей перед выбором компонентов
            ClearComboBox();

            // Выбор первого элемента в comboBox1
            if (comboBox1.Items.Count > 1)
            {
                comboBox1.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox3
            if (comboBox3.Items.Count > 1)
            {
                comboBox3.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox5
            if (comboBox5.Items.Count > 1)
            {
                comboBox5.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox7
            if (comboBox7.Items.Count > 1)
            {
                comboBox7.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox9
            if (comboBox9.Items.Count > 1)
            {
                comboBox9.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox11
            if (comboBox11.Items.Count > 1)
            {
                comboBox11.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox13
            if (comboBox13.Items.Count > 1)
            {
                comboBox13.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox15
            if (comboBox15.Items.Count > 1)
            {
                comboBox15.SelectedIndex = 1;
            }

            // Выбор первого элемента в comboBox17
            if (comboBox17.Items.Count > 1)
            {
                comboBox17.SelectedIndex = 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей перед выбором компонентов
            ClearComboBox();

            // Выбор первого элемента в comboBox1
            if (comboBox1.Items.Count > 2)
            {
                comboBox1.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox3
            if (comboBox3.Items.Count > 2)
            {
                comboBox3.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox5
            if (comboBox5.Items.Count > 2)
            {
                comboBox5.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox7
            if (comboBox7.Items.Count > 2)
            {
                comboBox7.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox9
            if (comboBox9.Items.Count > 2)
            {
                comboBox9.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox11
            if (comboBox11.Items.Count > 2)
            {
                comboBox11.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox13
            if (comboBox13.Items.Count > 2)
            {
                comboBox13.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox15
            if (comboBox15.Items.Count > 2)
            {
                comboBox15.SelectedIndex = 2;
            }

            // Выбор первого элемента в comboBox17
            if (comboBox17.Items.Count > 2)
            {
                comboBox17.SelectedIndex = 2;
            }
        }
    }
}
