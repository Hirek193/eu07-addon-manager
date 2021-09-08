using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MaSzyna_Unofficial_Content_Manager
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            if (File.Exists(path + "\\eu07.exe"))
            {
                textBox1.Text = path;
            }
            else
            {
                DialogResult res = MessageBox.Show("W wybranym folderze nie znaleziono pliky wykonywalnego symulatora. Czy chcesz kontynuować?",
                    "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    textBox1.Text = path;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Globals.config.data["CM_Config"]["simDir"] = textBox1.Text;
            Globals.config.saveChanges();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Globals.config.data["CM_Config"]["simDir"];
        }
    }
}
