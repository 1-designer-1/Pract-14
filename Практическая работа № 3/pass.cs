﻿using System;
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
    public partial class pass : Form
    {
        public pass()
        {
            InitializeComponent();
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(textBox1, "123");
        }

        private void button1_Click(object sender, EventArgs e) //Вход
        {
            if (textBox1.Text == "123")
            {
                Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль. Повторите ввод.");
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e) // отмена
        {
            this.Owner.Close();
        }
    }
}
