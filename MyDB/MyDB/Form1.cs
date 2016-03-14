using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDB
{
    public partial class Form1 : Form
    {
        //class Record
        //{
        //    private string _FIO;
        //    private string _Specialization;
        //    private string _Group;

        //    public Record(string FIO, string S, string G)
        //    {
        //        this._FIO = FIO;
        //        this._Specialization = S;
        //        this._Group = G;
        //    }
        //}

        //List<Record> DB = new List<Record>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearAllTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)//add new record
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                dataGridView1.Rows.Add(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
                ClearAllTextBoxes();
                //DB.Add(new Record(textBox1.Text, textBox2.Text, textBox3.Text));
            }
            else
                MessageBox.Show("Заполните все строки.");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)//save changes
        {
            dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;
            dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)//cencel changes
        {
            ClearAllTextBoxes();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)//save
        {
            Stream myStream = null;

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + '|');
                            }
                            if (i != dataGridView1.RowCount - 1)
                            {
                                myWriter.WriteLine();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                    myStream.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)//open
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(myStream);
                    dataGridView1.Rows.Clear();
                    string[] str;
                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        for (int i = 0; i < str1.Count(); i++)
                        {
                            str = str1[i].Split('|');
                            dataGridView1.Rows.Add(str[0], str[1], str[2]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }
                }
            }
        }
    }
}
