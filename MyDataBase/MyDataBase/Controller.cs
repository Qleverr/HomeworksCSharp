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
            grid.ReadOnly = true;

            CreateGridColumns(grid, file);
            CreateGridRows(grid, file);

            return grid;
        }

        private void CreateGridColumns(DataGridView grid, string file)
        {
            StreamReader reader = new StreamReader(file + "/main.txt");

            string columnName;
            while ((columnName = reader.ReadLine()) != null)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                grid.Columns.Add(column);
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
    }
}
