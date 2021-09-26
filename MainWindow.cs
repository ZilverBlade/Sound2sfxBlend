using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sound2sfxBlend;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;

namespace Sound2sfxBlend
{

    public partial class MainWindow : Form
    {
       
        public static BlendBuildingProgessDialogue progressDialogue;
        public static bool copyRatherThanMove = false;
        public static bool busyBuilding = false;
        public static bool onloadIsAlsoOffload = false;

        public MainWindow()
        {
            InitializeComponent();

        }

        #region help buttons
        private void hlpBlendName_Click(object sender, EventArgs e) => MessageBox.Show("This is the name that you give to your sound, make sure it's something unique, as it could overwrite other sounds unintentionally", "Blend Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void hlpSoundFldr_Click(object sender, EventArgs e) => MessageBox.Show("This is the folder with all of your sounds. Select the folder and you're good to go.", "Sound Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void OutputFldr_Click(object sender, EventArgs e) => MessageBox.Show("This is the folder where your created sound blend is put in.", "Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void hlpOnLoad_Click(object sender, EventArgs e) => MessageBox.Show("This is the text or character that is present on sound files that are for onload. Example: \"5000_ON.flac\" is an onload file, so you type in ON for the onload textbox", "On load", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void hlpOffLoad_Click(object sender, EventArgs e) =>MessageBox.Show("help", "Off load", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void hlpCopyNotMove_Click(object sender, EventArgs e) => MessageBox.Show("If you check this, rather than moving the sounds from your sound folder, it copies them over, preventing them from being moved around and such.", "Off load", MessageBoxButtons.OK, MessageBoxIcon.Information);


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Enabled = false;
            bool isAllowedToBuild = true;
            busyBuilding = true;
            timer1.Start();
            BlendBuilder blendBuilder = new BlendBuilder();

            progressDialogue = new BlendBuildingProgessDialogue();
            progressDialogue.Show();
            progressDialogue.UpdateProgressText(blendNameTxtBox.Text);

            for (int i = 0; i < IllegalBlendNames.illegalNames.Length; i++)
            {                
                if (blendNameTxtBox.Text == IllegalBlendNames.illegalNames[i])
                {
                    isAllowedToBuild = false;
                    progressDialogue.UpdateProgressText("Colliding blend name found: " + IllegalBlendNames.illegalNames[i]);
                    progressDialogue.UpdateProgressText("Cancelling blend creation...");
                    MessageBox.Show("You used a default BeamNG.drive blend name: " + Environment.NewLine + IllegalBlendNames.illegalNames[i] + Environment.NewLine + "Please change your blend name", "Illegal Blend Name Used!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    progressDialogue.Close();
                    break;
                }
                else
                {
                    progressDialogue.UpdateProgressBar(1);
                    progressDialogue.UpdateProgressText("Validated blend name compared to " + IllegalBlendNames.illegalNames[i]);
                }
            }

            if (isAllowedToBuild == true)
            {
                progressDialogue.UpdateProgressBar(true);
                blendBuilder.BuildBlend(blendNameTxtBox.Text, soundFolderTxtBox.Text, outputFolderTxtBox.Text, onLoadRulesTxtBox.Text, offLoadRulesTxtBox.Text, Convert.ToInt32(ignoreFirstCharsNumUD.Value), Convert.ToInt32(ignoreLastCharsNumUD.Value));
            }
            
        }

        private void onLoadRulesTxtBox_TextChanged(object sender, EventArgs e)
        {
           
            checkIfRulesAreEmpty();
        } 

        private void offLoadRulesTxtBox_TextChanged(object sender, EventArgs e)
        {
            checkIfRulesAreEmpty();
        }

        private void blendNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            checkIfRulesAreEmpty();
            blendNameTxtBox.Text = Regex.Replace(blendNameTxtBox.Text, @"[^\w\.@-]", "");
        }
        private void outputFolderTxtBox_TextChanged(object sender, EventArgs e)
        {
            checkIfRulesAreEmpty();
        }
        private void soundFolderTxtBox_TextChanged(object sender, EventArgs e)
        {
            checkIfRulesAreEmpty();
            UpdateSample();
        }

        void checkIfRulesAreEmpty()
        {
            if (blendNameTxtBox.Text != "" && soundFolderTxtBox.Text != "" && outputFolderTxtBox.Text != "")
            {
                if (onLoadRulesTxtBox.Text != "")
                {
                    button1.Enabled = true;
                }
                else if (offLoadRulesTxtBox.Text != "")
                {                  
                    button1.Enabled = true;
                }
                else if (checkBox2.Checked == true)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
                
            }
            if (onLoadRulesTxtBox.Text != "" && offLoadRulesTxtBox.Text == "")
            {
                label11.Text = "Since there is no offload rule, offload will be using files that do not match onload's rules";
                label11.Show();
            }
            else if (offLoadRulesTxtBox.Text != "" && onLoadRulesTxtBox.Text == "")
            {
                label11.Text = "Since there is no onload rule, onload will be using files that do not match offload's rules";
                label11.Show();
            }
            else
            {
                label11.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //displays correct ASSEMBLY version (not file version)
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            Type type1 = typeof(MainWindow);
            this.Text = "Sound2sfxBlend2D " + type1.Assembly.GetName().Version.Major + "." + type1.Assembly.GetName().Version.Minor + "." + type1.Assembly.GetName().Version.Build + "." + fileVersion.FileVersion.Substring(fileVersion.FileVersion.LastIndexOf(".") + 1) ;

            if (Properties.Settings.Default.autoCheckForUpdates == true) { checkForUpdateAsync.RunWorkerAsync(); } else { checkAutomaticallyToolStripMenuItem.Checked = false; }
        }

        private void checkForUpdateAsync_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckVersion();
        }

        private void CheckVersion(bool ranManually = false)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string v = client.DownloadString("https://pastebin.com/raw/XATmg05m");
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string getversion = v.Substring(v.IndexOf("$") + 1, v.LastIndexOf("$") - v.IndexOf("$") - 1);
                    Type type1 = typeof(MainWindow);

                    if (Convert.ToInt16(getversion.Substring(getversion.IndexOf("."), getversion.LastIndexOf(".")).Replace(".", "")) > type1.Assembly.GetName().Version.Minor)
                    {
                        if (MessageBox.Show($"There is a new version available (version {getversion}) {System.Environment.NewLine}Would you like to download it?", "Update") == DialogResult.Yes)
                        {
                            Process.Start(v.Substring(v.LastIndexOf("$") + 1));
                        }
                    }
                    else if (Convert.ToInt16(getversion.Substring(getversion.LastIndexOf(".") + 1)) > type1.Assembly.GetName().Version.Build && Convert.ToInt16(getversion.Substring(getversion.IndexOf("."), getversion.LastIndexOf(".")).Replace(".", "")) >= type1.Assembly.GetName().Version.Minor)
                    {
                        if (MessageBox.Show($"There is a new build available (version {getversion}) {System.Environment.NewLine}Would you like to download it?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Process.Start(v.Substring(v.LastIndexOf("$") + 1));
                        }
                    }
                    else if (ranManually == true)
                    {
                        MessageBox.Show("You're already on the latest version", $"Version {type1.Assembly.GetName().Version.Major + "." + type1.Assembly.GetName().Version.Minor + "." + type1.Assembly.GetName().Version.Build + "." + fileVersion.FileVersion.Substring(fileVersion.FileVersion.LastIndexOf(".") + 1)}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("An error occured while checking for update. Are you connected to the internet?", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateSample()
        {
            try
            {
                string x = System.IO.Directory.GetFiles(soundFolderTxtBox.Text)[0];

                var samplename = x.Substring(x.LastIndexOf(@"\") + 1);
                samplename = samplename.Remove(samplename.LastIndexOf("."));
                var samplenameext = x.Substring(x.LastIndexOf("."));
                samplename = samplename.Substring((int)ignoreFirstCharsNumUD.Value);
                samplename = samplename.Substring(0, samplename.Length - (int)ignoreLastCharsNumUD.Value);
                sampleFileNameLbl.Text = $"Sample: {samplename + samplenameext}";
            }
            catch { }
           
        }
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                copyRatherThanMove = true;
            }
            else
            {
                copyRatherThanMove = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (soundFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                soundFolderTxtBox.Text = soundFolderBrowserDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderTxtBox.Text = outputFolderBrowserDialog.SelectedPath;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                groupBox1.Enabled = false;
                onloadIsAlsoOffload = true;
            }
            else
            {
                groupBox1.Enabled = true;
                onloadIsAlsoOffload = false;
            }        
            checkIfRulesAreEmpty();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (busyBuilding == true)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                timer1.Stop();
            }
        }


        private void checkAutomaticallyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutomaticallyToolStripMenuItem.Checked==true)
            {
                Properties.Settings.Default.autoCheckForUpdates = true;
            }
            else
            {
                Properties.Settings.Default.autoCheckForUpdates = false;
            }
            Properties.Settings.Default.Save();
        }

        private void checkNowToolStripMenuItem_Click(object sender, EventArgs e) => CheckVersion(true);

        private void githubToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://github.com/ZilverBlade/Sound2sfxBlend/releases");
        
        private void beamNGForumPostToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://www.beamng.com/threads/sound-blend-file-creator-sfxblend2d-tool.81891/");

        private void youtubeVideoToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://www.youtube.com/watch?v=NWBxAukX_vg");

        private void ignoreFirstCharsNumUD_ValueChanged(object sender, EventArgs e) => UpdateSample();

        private void ignoreLastCharsNumUD_ValueChanged(object sender, EventArgs e) => UpdateSample();

    }
}
