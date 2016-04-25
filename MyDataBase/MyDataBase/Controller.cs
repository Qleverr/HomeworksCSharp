using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDataBase
{
    class Controller
    {
        public Controller()
        {
        }

        public void OpenFile(OpenFileDialog openFileDialog, TabControl tabControl)
        {
            Stream stream = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    StreamReader reader = new StreamReader(stream);
                    string pageName;
                    while ((pageName = reader.ReadLine()) != null)
                    {
                        TabPage newPage = new TabPage(pageName);
                        newPage.Controls.Add(CreateGridByFile(pageName));
                        newPage.Controls.Add(SetAddButton());
                        newPage.Controls.Add(SetDeleteButton());
                        tabControl.TabPages.Add(newPage);
                        tabControl.Refresh();
                    }
                }
            }
        }

        private DataGridView CreateGridByFile(string file)
        {
            DataGridView grid = new DataGridView();

            grid.Size = new Size(635, 240);
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = false;

            CreateGridColumns(grid, file);
            CreateGridRows(grid, file);

            return grid;
        }

        private void CreateGridColumns(DataGridView grid, string file)
        {
            StreamReader reader = new StreamReader(file + "/main.txt");

            try
            {
                string columnName;
                while ((columnName = reader.ReadLine()) != null)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.HeaderText = columnName;
                    grid.Columns.Add(column);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            reader.Close();
        }

        private void CreateGridRows(DataGridView grid, string file)
        {
            StreamReader reader = new StreamReader(file + "/data.txt");

            string[] info;
            int num = 0;
            try
            {
                string[] lineInfo = reader.ReadToEnd().Split('\n');
                num = lineInfo.Count();
                for (int i = 0; i < num; i++)
                {
                    info = lineInfo[i].Split(' ');
                    grid.Rows.Add(info);
                    //for (int j = 0; j < grid.ColumnCount; j++)
                    //{
                    //    grid.Rows[i].Cells[j].Value = info[j];
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            reader.Close();
        }

        private Button SetAddButton()
        {
            Button addButton = new Button();

            addButton.Size = new Size(100, 25);
            addButton.Location = new Point(130, 250);
            addButton.Text = "Добавить";
            addButton.Name = "AddButton";
            addButton.Click += AddButton_Click;

            return addButton;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)((Button)sender).Parent.Controls[0];
            grid.Rows.Add();
        }

        private Button SetDeleteButton()
        {
            Button deleteButton = new Button();

            deleteButton.Size = new Size(100, 25);
            deleteButton.Location = new Point(260, 250);
            deleteButton.Text = "Удалить";
            deleteButton.Name = "DeleteButton";
            deleteButton.Click += DeleteButton_Click;

            return deleteButton;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)((Button)sender).Parent.Controls[0];
            grid.Rows.Remove(grid.CurrentRow);
        }

        //private EventHandler AddButton_Click(Control control)
        //{
        //    int tabIndex = (int)(((Button)sender).Tag);
        //}

        public void SaveFile(SaveFileDialog saveFileDialog, TabControl tabControl)
        {
            
        }
    }
}
