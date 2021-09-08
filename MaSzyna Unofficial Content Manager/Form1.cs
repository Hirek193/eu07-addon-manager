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
using Newtonsoft.Json;
using System.Diagnostics;
using Downloader;
using System.IO;
using System.Net;
using System.Reflection;
using System.IO.Compression;
using System.Runtime;


namespace MaSzyna_Unofficial_Content_Manager
{
    public partial class Form1 : Form
    {
        class ErrorMessage
        {
            [JsonProperty("message")]
            public string errmsg;
            [JsonProperty("traceCode")]
            public string code;
        }

        
        List<Addon> addonList;
        List<Addon> tempAddonList;
        DownloaderForm dlForm;
        
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists("config.ini"))
            {
                File.CreateText("config.ini").Close();
                using (StreamWriter sw = new StreamWriter("config.ini"))
                {
                    sw.WriteLine("[CM_Config]");
                    sw.WriteLine("simDir = ");
                }
            }
            Globals.config = new ConfigManager("config.ini");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dlForm = new DownloaderForm();
            var client = new RestClient(Globals.apiUrl + "/getAddons");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            addonList = JsonConvert.DeserializeObject<List<Addon>>(response.Content);
            listBox1.DataSource = addonList;
            listBox1.DisplayMember = "displayName";

            if (Globals.config.data["CM_Config"]["simDir"] == null ||
                Globals.config.data["CM_Config"]["simDir"] == "")
            {
                MessageBox.Show("Nie przypisano ścieżki symulatora! Proszę przypisać ścieżkę w ustawieniach!",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SettingsForm sf = new SettingsForm();
                sf.ShowDialog();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.DataSource == addonList)
            {
                textBox1.Text = string.Format("Kategoria: {4}\r\nNazwa dodatku: {0}\r\nOpis: {1}\r\n" +
    "Werjsa: {2}\r\nAutor: {3}", addonList[listBox1.SelectedIndex].name,
    addonList[listBox1.SelectedIndex].description, addonList[listBox1.SelectedIndex].version,
    addonList[listBox1.SelectedIndex].author, addonList[listBox1.SelectedIndex].addonType);
            }
            else if (listBox1.DataSource == tempAddonList)
            {
                textBox1.Text = string.Format("Kategoria: {4}\r\nNazwa dodatku: {0}\r\nOpis: {1}\r\n" +
    "Werjsa: {2}\r\nAutor: {3}", tempAddonList[listBox1.SelectedIndex].name,
    tempAddonList[listBox1.SelectedIndex].description, tempAddonList[listBox1.SelectedIndex].version,
    tempAddonList[listBox1.SelectedIndex].author, tempAddonList[listBox1.SelectedIndex].addonType);
            }
            if(addonList.Count != 0 || tempAddonList.Count != 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient(Globals.apiUrl + "/getAddons");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            addonList = JsonConvert.DeserializeObject<List<Addon>>(response.Content);
            listBox1.DataSource = addonList;
            listBox1.DisplayMember = "displayName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.apiUrl + "/getAddon/" + addonList[listBox1.SelectedIndex].id.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Globals.config.data["CM_Config"]["simDir"] == null ||
                Globals.config.data["CM_Config"]["simDir"] == "")
            {
                MessageBox.Show("Nie przypisano ścieżki symulatora! Pobieranie dodatków nie jest możliwe!",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string cacheDir = Application.StartupPath + @"\.cache\";
                string apiRequest = Globals.apiUrl + "/getAddon/" + addonList[listBox1.SelectedIndex].id.ToString();

                // Check is available
                var client = new RestClient(Globals.apiUrl + "/getAddon/" + addonList[listBox1.SelectedIndex].id.ToString());
                var request = new RestRequest(Method.HEAD);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Downloading
                    var dlParams = new DownloadConfiguration()
                    {

                        MaxTryAgainOnFailover = 3,
                        TempDirectory = cacheDir + "dl/",
                        Timeout = 2000,
                        RequestConfiguration =
                        {
                            Accept = "*/*",
                            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                            ProtocolVersion = HttpVersion.Version11, // Default value is HTTP 1.1
                            UseDefaultCredentials = false,
                            //UserAgent = $"DownloaderSample/{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}"
                        }
                    };
                    var dl = new DownloadService(dlParams);
                    string addonFilePath = cacheDir + addonList[listBox1.SelectedIndex].id + ".zip";
                    dl.DownloadFileTaskAsync(apiRequest, addonFilePath);
                    dl.DownloadProgressChanged += onDlProgressChanged;
                    dl.DownloadFileCompleted += onDlCompleted;
                    dlForm.ShowDialog();

                    if (Directory.Exists(cacheDir + @"\currentInstall\")) Directory.Delete(cacheDir + @"\currentInstall\", true);
                    ZipFile.ExtractToDirectory(addonFilePath, cacheDir + @"\currentInstall\"); // it's temp dir for installing current addon

                    // Move to destination
                    string dest = Globals.config.data["CM_Config"]["simDir"] + "\\";

                    string rootFolderPath = cacheDir + @"\currentInstall\";
                    string[] fileList = Directory.GetFiles(rootFolderPath, "*", SearchOption.AllDirectories);
                    foreach (string file in fileList)
                    {
                        string fileToMove = file;
                        string moveTo = file.Replace(rootFolderPath, dest);
                        //MessageBox.Show(fileToMove + "\n" + moveTo);
                        //moving file
                        if (!File.Exists(moveTo))
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(moveTo)))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(moveTo));
                            }
                            File.Move(fileToMove, moveTo);
                        }
                        else
                        {
                            string msgBox = string.Format("Plik \"{0}\" już istnieje. Czy chcesz go zamienić?",
                                fileToMove.Replace(rootFolderPath, ""));
                            DialogResult res = MessageBox.Show(msgBox, "Plik istnieje",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (res == DialogResult.Yes)
                            {
                                File.Delete(moveTo);
                                File.Move(fileToMove, moveTo);
                            }
                        }
                    }
                    File.Delete(addonFilePath);
                    //Directory.Delete(cacheDir + @"\currentInstall\", true);
                    MessageBox.Show("Dodatek zainstalowany pomyślnie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("notepad.exe", Globals.config.data["CM_Config"]["simDir"] + @"\info.txt"); // Open readme
                }
                else
                {
                    request = new RestRequest(Method.GET);
                    response = client.Execute(request);
                    ErrorMessage errMsg = JsonConvert.DeserializeObject<ErrorMessage>(response.Content);
                    string messageToShow = string.Format("Wystąpił błąd podczas pobierania dodatku!\n" +
                        "Interfejs zwrócił: \"{0}\". Skontaktuj się z administratorem i podaj mu następujący kod wydarzenia: \"{1}\".", errMsg.errmsg, errMsg.code);
                    MessageBox.Show(messageToShow, "Błąd podczas pobierania dodatku!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void onDlProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e)
        {
            double dlSpeed = e.BytesPerSecondSpeed / 1024;
            float dlSpeedMb = (float)dlSpeed / 1024;

            string text = string.Format("Prędkość pobierania: {0:0.00}KB/s", dlSpeed);
            if (dlSpeed > 1024)
            {
                text = string.Format("Prędkość pobierania: {0:0.00}MB/s", dlSpeedMb);
            }
            if (dlForm.label1.InvokeRequired)
            {
                dlForm.label1.BeginInvoke((MethodInvoker)delegate () { dlForm.label1.Text = text; ; });
            }
            else
            {
                dlForm.label1.Text = text; ;
            }
            if (dlForm.progressBar1.InvokeRequired)
            {
                dlForm.progressBar1.BeginInvoke((MethodInvoker)delegate () { dlForm.progressBar1.Value = (int)e.ProgressPercentage; ; });
            }
            else
            {
                dlForm.progressBar1.Value = (int)e.ProgressPercentage; ;
            }
            if (dlForm.label2.InvokeRequired)
            {
                dlForm.label2.BeginInvoke((MethodInvoker)delegate () { dlForm.label2.Text = "Pobierany dodatek: " + addonList[listBox1.SelectedIndex].name; ; });
            }
            else
            {
                dlForm.label2.Text = "Pobierany dodatek: " + addonList[listBox1.SelectedIndex].name;
            }
            switch (dlForm.label3.InvokeRequired)
            {
                case (true):
                    dlForm.label3.BeginInvoke((MethodInvoker)delegate () { dlForm.label3.Text = string.Format("Pobrano: {0:0.00}MB/{1:0.00}MB", (float)e.ReceivedBytesSize / 1024 / 1024, (float)e.TotalBytesToReceive / 1024 / 1024); });
                    break;
                case (false):
                    dlForm.label3.Text = string.Format("Pobrano: {0:0.00}MB/{1:0.00}MB", (float)e.ReceivedBytesSize / 1024 / 1024, (float)e.TotalBytesToReceive / 1024 / 1024);
                    break;
            }
            switch (dlForm.InvokeRequired)
            {
                case (true):
                    dlForm.BeginInvoke((MethodInvoker)delegate () { dlForm.Text = string.Format("Pobieranie dodatku - {0}%", (int)e.ProgressPercentage); });
                    break;
                case (false):
                    dlForm.Text = string.Format("Pobieranie dodatku - {0}%", (int)e.ProgressPercentage);
                    break;
            }

        }

        private void onDlCompleted(object sender, AsyncCompletedEventArgs e)
        {
            dlForm.Invoke(new MethodInvoker(dlForm.Hide));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempAddonList = new List<Addon>();
            foreach (Addon addon in addonList)
            {
                if (addon.addonType == comboBox1.Text)
                {
                    tempAddonList.Add(addon);
                    listBox1.DataSource = null;
                    listBox1.DisplayMember = null;
                    listBox1.DataSource = tempAddonList;
                    listBox1.DisplayMember = "displayName";
                    if(tempAddonList.Count == 0)
                    {
                        listBox1.DataSource = null;
                        listBox1.DisplayMember = null;
                        listBox1.Items.Clear();
                    }
                }
                else if (comboBox1.Text.Contains("wszystkie"))
                {
                    listBox1.DataSource = null;
                    listBox1.DisplayMember = null;
                    listBox1.DataSource = addonList;
                    listBox1.DisplayMember = "displayName";
                }

                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            uploadAddon upAd = new uploadAddon();
            upAd.ShowDialog();
            var client = new RestClient(Globals.apiUrl + "/getAddons");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            addonList = JsonConvert.DeserializeObject<List<Addon>>(response.Content);
            listBox1.DataSource = addonList;
            listBox1.DisplayMember = "displayName";
        }
    }
}
