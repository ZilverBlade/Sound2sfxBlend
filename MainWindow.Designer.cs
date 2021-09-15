
namespace Sound2sfxBlend
{
    partial class MainWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.offLoadRulesTxtBox = new System.Windows.Forms.TextBox();
            this.onLoadRulesTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.OutputFldr = new System.Windows.Forms.Button();
            this.hlpSoundFldr = new System.Windows.Forms.Button();
            this.hlpBlendName = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.soundFolderTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.outputFolderTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.blendNameTxtBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.soundFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(313, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Blends!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "On load";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.offLoadRulesTxtBox);
            this.groupBox1.Controls.Add(this.onLoadRulesTxtBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(349, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rules";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(191, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 49);
            this.label11.TabIndex = 14;
            this.label11.Text = "Since there is no <onload/offload> rule, <onload/offload> will be using files tha" +
    "t do not match <offload/offload>\'s rules";
            this.label11.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "characters";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(79, 132);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(30, 20);
            this.numericUpDown2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ignore last";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "characters";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(79, 106);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(30, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ignore first";
            // 
            // offLoadRulesTxtBox
            // 
            this.offLoadRulesTxtBox.Enabled = false;
            this.offLoadRulesTxtBox.Location = new System.Drawing.Point(194, 74);
            this.offLoadRulesTxtBox.Name = "offLoadRulesTxtBox";
            this.offLoadRulesTxtBox.Size = new System.Drawing.Size(209, 20);
            this.offLoadRulesTxtBox.TabIndex = 7;
            this.offLoadRulesTxtBox.TextChanged += new System.EventHandler(this.offLoadRulesTxtBox_TextChanged);
            // 
            // onLoadRulesTxtBox
            // 
            this.onLoadRulesTxtBox.Location = new System.Drawing.Point(194, 37);
            this.onLoadRulesTxtBox.Name = "onLoadRulesTxtBox";
            this.onLoadRulesTxtBox.Size = new System.Drawing.Size(209, 20);
            this.onLoadRulesTxtBox.TabIndex = 6;
            this.onLoadRulesTxtBox.TextChanged += new System.EventHandler(this.onLoadRulesTxtBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "WARNING! This tool will look for any numbers and use them as RPM values\r\nIf you w" +
    "ant to avoid this potential issue, make use of the ignore characters above\r\n";
            this.label3.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Contains",
            "Doesn\'t Contain"});
            this.comboBox2.Location = new System.Drawing.Point(67, 72);
            this.comboBox2.MaxDropDownItems = 2;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "Contains";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Off load";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Contains",
            "Doesn\'t Contain"});
            this.comboBox1.Location = new System.Drawing.Point(67, 36);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Contains";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.OutputFldr);
            this.groupBox2.Controls.Add(this.hlpSoundFldr);
            this.groupBox2.Controls.Add(this.hlpBlendName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.soundFolderTxtBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.outputFolderTxtBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.blendNameTxtBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 225);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files and Location";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(297, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 22);
            this.button4.TabIndex = 25;
            this.button4.Text = "?";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 200);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(178, 17);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Copy files over rather than move";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 22);
            this.button2.TabIndex = 23;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(232, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 22);
            this.button3.TabIndex = 22;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OutputFldr
            // 
            this.OutputFldr.Location = new System.Drawing.Point(298, 103);
            this.OutputFldr.Name = "OutputFldr";
            this.OutputFldr.Size = new System.Drawing.Size(28, 22);
            this.OutputFldr.TabIndex = 20;
            this.OutputFldr.Text = "?";
            this.OutputFldr.UseVisualStyleBackColor = true;
            this.OutputFldr.Click += new System.EventHandler(this.OutputFldr_Click);
            // 
            // hlpSoundFldr
            // 
            this.hlpSoundFldr.Location = new System.Drawing.Point(298, 80);
            this.hlpSoundFldr.Name = "hlpSoundFldr";
            this.hlpSoundFldr.Size = new System.Drawing.Size(28, 22);
            this.hlpSoundFldr.TabIndex = 19;
            this.hlpSoundFldr.Text = "?";
            this.hlpSoundFldr.UseVisualStyleBackColor = true;
            this.hlpSoundFldr.Click += new System.EventHandler(this.hlpSoundFldr_Click);
            // 
            // hlpBlendName
            // 
            this.hlpBlendName.Location = new System.Drawing.Point(298, 38);
            this.hlpBlendName.Name = "hlpBlendName";
            this.hlpBlendName.Size = new System.Drawing.Size(28, 22);
            this.hlpBlendName.TabIndex = 16;
            this.hlpBlendName.Text = "?";
            this.hlpBlendName.UseVisualStyleBackColor = true;
            this.hlpBlendName.Click += new System.EventHandler(this.hlpBlendName_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sound folder:";
            // 
            // soundFolderTxtBox
            // 
            this.soundFolderTxtBox.Location = new System.Drawing.Point(78, 81);
            this.soundFolderTxtBox.Name = "soundFolderTxtBox";
            this.soundFolderTxtBox.Size = new System.Drawing.Size(148, 20);
            this.soundFolderTxtBox.TabIndex = 17;
            this.soundFolderTxtBox.TextChanged += new System.EventHandler(this.soundFolderTxtBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Output folder:";
            // 
            // outputFolderTxtBox
            // 
            this.outputFolderTxtBox.Location = new System.Drawing.Point(78, 104);
            this.outputFolderTxtBox.Name = "outputFolderTxtBox";
            this.outputFolderTxtBox.Size = new System.Drawing.Size(148, 20);
            this.outputFolderTxtBox.TabIndex = 15;
            this.outputFolderTxtBox.TextChanged += new System.EventHandler(this.outputFolderTxtBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Blend name:";
            // 
            // blendNameTxtBox
            // 
            this.blendNameTxtBox.Location = new System.Drawing.Point(78, 39);
            this.blendNameTxtBox.Name = "blendNameTxtBox";
            this.blendNameTxtBox.Size = new System.Drawing.Size(214, 20);
            this.blendNameTxtBox.TabIndex = 0;
            this.blendNameTxtBox.TextChanged += new System.EventHandler(this.blendNameTxtBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7432, 2863);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "x";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 290);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Beamng | Sound > sfxBlend2D converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox offLoadRulesTxtBox;
        private System.Windows.Forms.TextBox onLoadRulesTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button OutputFldr;
        private System.Windows.Forms.Button hlpSoundFldr;
        private System.Windows.Forms.Button hlpBlendName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox soundFolderTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox outputFolderTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox blendNameTxtBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog soundFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog outputFolderBrowserDialog;
    }
}

