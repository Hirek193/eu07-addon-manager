using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.IO;
using System.Collections.Specialized;

namespace MaSzyna_Unofficial_Content_Manager
{
    public partial class uploadAddon : Form
    {
        

        public uploadAddon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uwaga!!!\n" +
                "Podczas przesyłania dodatku aplikacja może nie odpowiadać. Należy w tym" +
                " momencie czekać na zakończenie procesu.\n" +
                "\n" +
                "Wciśnięcie przycisku OK rozpocznie przesyłanie dodatku!", "Disclaimer",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("name", addonName.Text);
            queryString.Add("description", addonDescription.Text);
            queryString.Add("author", addonAuthor.Text);
            queryString.Add("version", addVersion.Text);
            queryString.Add("type", addType.Text);

            var client = new RestClient(Globals.apiUrl + "/addAddon?" + queryString.ToString());
            var request = new RestRequest(Method.POST);
            request.AddHeader("uploader-token", uploaderToken.Text);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddParameter("application/octet-stream", File.ReadAllBytes(filepath.Text), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            canEnableButton();
            Globals.config.data["CM_Config"]["uploader_token"] = uploaderToken.Text;
            Globals.config.saveChanges();
        }

        private void canEnableButton()
        {
            if (uploaderToken.Text != "" && filepath.Text != "" && addonName.Text != "" && addonDescription.Text != "" &&
                addonAuthor.Text != "" && addVersion.Text != "" && addType.Text != "") button1.Enabled = true;
            else button1.Enabled = false;
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            canEnableButton();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            canEnableButton();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            canEnableButton();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            canEnableButton();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            canEnableButton();
        }

        private void uploadAddon_Load(object sender, EventArgs e)
        {
            uploaderToken.Text = Globals.config.data["CM_Config"]["uploader_token"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            filepath.Text = openFileDialog1.FileName;
        }
    }
}
