using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSteganoApp
{
    public partial class EncodeForm : Form
    {
        string message = "";
        string key = "";
        bool terminator = false;

        private string Message_Encode(string _mess, string _key, bool _term) { 
            string API_message = _mess + "\u0000" + "\u0000" + "\u0000" + _key + "\u0000" + "\u0000" + "\u0000";
            if (_term)
            {
                API_message += "111";
            }
            else
            {
                API_message += "000";
            }
            return API_message;
        }
        public EncodeForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            message = MessageBox.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            key = KeyBox.Text;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            terminator = checkBox2.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //submit
        {
            Message_Encode(message, key, terminator); // todo
        }
    }
}
