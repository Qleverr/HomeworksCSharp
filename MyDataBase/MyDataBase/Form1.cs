using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDataBase
{
    public partial class Form1 : Form
    {
        private Controller _controller;

        public Form1()
        {
            InitializeComponent();
            this._controller = new Controller();
        }

        private void Button_SetBD_Click(object sender, EventArgs e)
        {
            _controller.OpenFile(this.openFileDialog1, this.tabControl1);
        }

        private void Button_SaveBD_Click(object sender, EventArgs e)
        {
            _controller.SaveFile(this.saveFileDialog1, this.tabControl1);
        }
    }
}
