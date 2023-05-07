using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ghost_Keyboard_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            // Show a message box with the value of the numeric up/down control
            MessageBox.Show(numericUpDown1.Value.ToString());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
