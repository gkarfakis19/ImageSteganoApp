using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using RestSharp;

namespace ImageSteganoApp
{
    public partial class EncodeForm : Form
    {
        string message = "";
        string key = "";
        bool terminator = false;
        bool image_given = false;
        string image_name = "";
        RestClient client = new RestClient("https://gkwebsite.herokuapp.com/");

        private void Message_Encode(string _mess, string _key, bool _term) {
            string terminate;
            if (_term)
            {
                terminate = "true";
            }
            else
            {
                terminate = "false";
            }
            RestRequest request = new RestRequest("api/encode");
            request.AddQueryParameter("message", _mess);
            request.AddQueryParameter("key", _key);
            request.AddQueryParameter("terminator", terminate);
            if (image_given)
            {
                request.AddFile("photo_upload", image_name);
            }

            string filePath="encodedimage.png";
            var writer = File.OpenWrite(filePath);

            request.ResponseWriter = responseStream =>
            {
                using (responseStream)
                {
                    responseStream.CopyTo(writer);
                }
            };
            var response=client.Post(request);
            writer.Close();
            
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
                image_name = openFileDialog1.FileName;
                Console.WriteLine(image_name);
                image_given = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //submit
        {
            Message_Encode(message, key, terminator);
        }

        private void EncodeForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mForm = new MainForm();
            this.Hide();
            mForm.ShowDialog();
            this.Close();
        }
    }
}
