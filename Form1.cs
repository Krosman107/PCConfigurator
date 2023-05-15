using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqliteConnection DB;
        private int idcpu;
        private int[] arr = new int[1];
        private int[] arr2 = new int[1];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SqliteConnection("Data Source=database.db; Version=3");
            DB.Open();

            var CMD = new SqliteCommand("select name from cpu", DB);
            var SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox1.Items.Add((string)SQL["name"]);
            }
            CMD = new SqliteCommand("SELECT name FROM motherboard", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox3.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM cooler", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox5.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM gpu", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox7.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM ram", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox9.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM hard_drive", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox11.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM ssd", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox13.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM power_supply", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox15.Items.Add((string)SQL["name"]);
            }

            CMD = new SqliteCommand("SELECT name FROM case", DB);
            SQL = CMD.ExecuteReader();
            while (SQL.Read())
            {
                comboBox17.Items.Add((string)SQL["name"]);
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
            var CMD1 = new SqliteCommand("select * from cpu where name=@cb1", DB);
            CMD1.Parameters.Add("@cb1", (SqliteType)DbType.String).Value = comboBox1.Text;
            var SQL1 = CMD1.ExecuteReader();
            while (SQL1.Read())
            {
                textBox1.Text += SQL1["price"];
                textBox2.Text += SQL1["info"];
                idcpu = Convert.ToInt32(SQL1["id"]);
                arr2[0] = Convert.ToInt32(SQL1["top"]);
                textBox20.Text += SQL1["top"];
            }
            arr[0] = Convert.ToInt32(textBox1.Text);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            var CMD2 = new SqliteCommand("select * from motherboard where name=@cb2", DB);
            CMD2.Parameters.Add("@cb2", (SqliteType)DbType.String).Value = comboBox3.Text;
            var SQL2 = CMD2.ExecuteReader();
            while (SQL2.Read())
            {
                textBox3.Text += SQL2["price"];
                textBox4.Text += SQL2["info"];
                idcpu = Convert.ToInt32(SQL2["id"]);
                arr2[0] = Convert.ToInt32(SQL2["top"]);
            }
            arr[0] = Convert.ToInt32(textBox3.Text);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            var CMD3 = new SqliteCommand("select * from cooler where name=@cb3", DB);
            CMD3.Parameters.Add("@cb3", (SqliteType)DbType.String).Value = comboBox5.Text;
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
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            var CMD4 = new SqliteCommand("select * from GPU where name=@cb4", DB);
            CMD4.Parameters.Add("@cb4", (SqliteType)DbType.String).Value = comboBox7.Text;
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
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox10.Clear();
            var CMD5 = new SqliteCommand("select * from RAM where name=@cb5", DB);
            CMD5.Parameters.Add("@cb5", (SqliteType)DbType.String).Value = comboBox9.Text;
            var SQL5 = CMD5.ExecuteReader();
            while (SQL5.Read())
            {
                textBox5.Text += SQL5["price"];
                textBox6.Text += SQL5["info"];
                idcpu = Convert.ToInt32(SQL5["id"]);
                arr2[0] = Convert.ToInt32(SQL5["top"]);
            }
            arr[0] = Convert.ToInt32(textBox9.Text);
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox12.Clear();
            var CMD6 = new SqliteCommand("select * from Hard disk where name=@cb6", DB);
            CMD6.Parameters.Add("@cb6", (SqliteType)DbType.String).Value = comboBox11.Text;
            var SQL6 = CMD6.ExecuteReader();
            while (SQL6.Read())
            {
                textBox7.Text += SQL6["price"];
                textBox8.Text += SQL6["info"];
                idcpu = Convert.ToInt32(SQL6["id"]);
                arr2[0] = Convert.ToInt32(SQL6["top"]);
                textBox22.Text += SQL6["top"];
            }
            arr[0] = Convert.ToInt32(textBox11.Text);
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox13.Clear();
            textBox14.Clear();
            var CMD7 = new SqliteCommand("select * from SSD where name=@cb7", DB);
            CMD7.Parameters.Add("@cb7", (SqliteType)DbType.String).Value = comboBox13.Text;
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
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox15.Clear();
            textBox16.Clear();
            var CMD8 = new SqliteCommand("select * from power supply where name=@cb8", DB);
            CMD8.Parameters.Add("@cb8", (SqliteType)DbType.String).Value = comboBox15.Text;
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
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Clear();
            textBox18.Clear();
            var CMD9 = new SqliteCommand("select * from case where name=@cb9", DB);
            CMD9.Parameters.Add("@cb9", (SqliteType)DbType.String).Value = comboBox17.Text;
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
        private void button1_Click(object sender, EventArgs e)
        {
            // Очистка данных во всех текстовых полях
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;
            textBox13.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox16.Text = string.Empty;
            textBox17.Text = string.Empty;
            textBox18.Text = string.Empty;
            textBox19.Text = string.Empty;
            textBox20.Text = string.Empty;
            textBox21.Text = string.Empty;
            textBox22.Text = string.Empty;
            textBox23.Text = string.Empty;
            textBox24.Text = string.Empty;
            // Сброс значений во всех комбо-боксах
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
            comboBox11.SelectedIndex = -1;
            comboBox12.SelectedIndex = -1;
            comboBox13.SelectedIndex = -1;
            comboBox14.SelectedIndex = -1;
            comboBox15.SelectedIndex = -1;
            comboBox16.SelectedIndex = -1;
            comboBox17.SelectedIndex = -1;
            comboBox18.SelectedIndex = -1;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
