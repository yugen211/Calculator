using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || "0123456789+-*/%(),".Contains(e.KeyChar));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var table = new DataTable();
            string formula = textBox1.Text.Replace(",", ".");
            var result = table.Compute(formula, "");
            textBox1.Text = result.ToString();
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }
    }
}
