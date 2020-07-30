using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace ImageSteganoApp
{
    public partial class DecodeForm : Form
    {
        RestClient client = new RestClient("https://gkwebsite.herokuapp.com/");
        string key = "";
        bool image_given = false;
        string image_name = "";
        public DecodeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MessageBox_TextChanged(object sender, EventArgs e) //keybox
        {
            key = MessageBox.Text;
        }

        private void button2_Click(object sender, EventArgs e) //submit
        {
            RestRequest request = new RestRequest("api/decode");
            if (image_given)
            {
                request.AddFile("photo_upload", image_name);
                request.AddQueryParameter("key", key);
                string filePath = "Decodedmessage.txt";
                var writer = File.OpenWrite(filePath);

                request.ResponseWriter = responseStream =>
                {
                    using (responseStream)
                    {
                        responseStream.CopyTo(writer);
                    }
                };
                var response = client.Post(request);
                writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image_name = openFileDialog1.FileName;
                Console.WriteLine(image_name);
                image_given = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mForm = new MainForm();
            this.Hide();
            mForm.ShowDialog();
            this.Close();
        }
    }
}
