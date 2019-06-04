using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            loadBUT.Enabled = false;
        }

        private void newBUT_Click(object sender, EventArgs e)
        {
            //Open Character Creation Screen
            this.Hide();
            var newwindow = new NewChar();
            newwindow.Show();
        }
    }
}
