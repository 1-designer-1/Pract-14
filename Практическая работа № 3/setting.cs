using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа___3
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }
        public int row
        {
            get { return Convert.ToInt32(numericUpDown1.Value); }
        }
        public int col 
        {
            get { return Convert.ToInt32(numericUpDown2.Value); }    
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            ColumnRows.Row = Convert.ToInt32(numericUpDown1.Value);
            ColumnRows.Col = Convert.ToInt32(numericUpDown2.Value);
            Close();
        }
    }
}
