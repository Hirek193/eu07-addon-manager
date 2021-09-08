
namespace MaSzyna_Unofficial_Content_Manager
{
    partial class uploadAddon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uploaderToken = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filepath = new System.Windows.Forms.TextBox();
            this.addonName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addonDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addonAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uploaderToken
            // 
            this.uploaderToken.Location = new System.Drawing.Point(16, 318);
            this.uploaderToken.Name = "uploaderToken";
            this.uploaderToken.PasswordChar = '*';
            this.uploaderToken.Size = new System.Drawing.Size(203, 20);
            this.uploaderToken.TabIndex = 0;
            this.uploaderToken.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(16, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Prześlij";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Token uploadera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ścieżka do pliku dodatku";
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(13, 30);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(177, 20);
            this.filepath.TabIndex = 4;
            // 
            // addonName
            // 
            this.addonName.Location = new System.Drawing.Point(13, 70);
            this.addonName.Name = "addonName";
            this.addonName.Size = new System.Drawing.Size(206, 20);
            this.addonName.TabIndex = 6;
            this.addonName.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nazwa dodatku:";
            // 
            // addonDescription
            // 
            this.addonDescription.Location = new System.Drawing.Point(13, 110);
            this.addonDescription.Multiline = true;
            this.addonDescription.Name = "addonDescription";
            this.addonDescription.Size = new System.Drawing.Size(206, 69);
            this.addonDescription.TabIndex = 8;
            this.addonDescription.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Opis dodatku:";
            // 
            // addonAuthor
            // 
            this.addonAuthor.Location = new System.Drawing.Point(13, 199);
            this.addonAuthor.Name = "addonAuthor";
            this.addonAuthor.Size = new System.Drawing.Size(206, 20);
            this.addonAuthor.TabIndex = 10;
            this.addonAuthor.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Autor dodatku:";
            // 
            // addVersion
            // 
            this.addVersion.Location = new System.Drawing.Point(13, 239);
            this.addVersion.Name = "addVersion";
            this.addVersion.Size = new System.Drawing.Size(206, 20);
            this.addVersion.TabIndex = 12;
            this.addVersion.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Wersja dodatku:";
            // 
            // addType
            // 
            this.addType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addType.FormattingEnabled = true;
            this.addType.Items.AddRange(new object[] {
            "MODEL",
            "SCENERY",
            "RESKIN",
            "SOUNDMOD",
            "MISC"});
            this.addType.Location = new System.Drawing.Point(13, 278);
            this.addType.Name = "addType";
            this.addType.Size = new System.Drawing.Size(206, 21);
            this.addType.TabIndex = 13;
            this.addType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Typ dodatku:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 20);
            this.button2.TabIndex = 15;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archiwum ZIP|*.zip";
            this.openFileDialog1.Title = "Wybierz plik dodatku";
            // 
            // uploadAddon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 373);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addType);
            this.Controls.Add(this.addVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addonAuthor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addonDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addonName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uploaderToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "uploadAddon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Przesyłanie dodatku";
            this.Load += new System.EventHandler(this.uploadAddon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uploaderToken;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.TextBox addonName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addonDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addonAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox addType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}