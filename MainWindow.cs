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
namespace Sound2sfxBlend
{

    public partial class MainWindow : Form
    {
        public static BlendBuildingProgessDialogue progressDialogue;
        public static bool copyRatherThanMove = false;
        public static bool onloadIsAlsoOffload = false;

        public MainWindow()
        {
            InitializeComponent();

        }

        #region help buttons
        private void hlpBlendName_Click(object sender, EventArgs e) {
            MessageBox.Show("This is the name that you give to your sound, make sure it's something unique, as it could overwrite other sounds unintentionally", "Blend Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hlpSoundFldr_Click(object sender, EventArgs e) {
            MessageBox.Show("This is the folder with all of your sounds. Select the folder and you're good to go.", "Sound Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OutputFldr_Click(object sender, EventArgs e) {
            MessageBox.Show("This is the folder where your created sound blend is put in.", "Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hlpOnLoad_Click(object sender, EventArgs e) {
            MessageBox.Show("help", "On load", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hlpOffLoad_Click(object sender, EventArgs e) {
            MessageBox.Show("help", "Off load", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (blendNameTxtBox.Text.Contains(""))
            {

            }

            bool isAllowedToBuild = true;

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
                    MessageBox.Show("You used a default BeamNG.drive blend name: " + System.Environment.NewLine + IllegalBlendNames.illegalNames[i] + System.Environment.NewLine + "Please change your blend name", "Illegal Blend Name Used!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                blendBuilder.BuildBlend(blendNameTxtBox.Text, soundFolderTxtBox.Text, outputFolderTxtBox.Text, onLoadRulesTxtBox.Text, offLoadRulesTxtBox.Text);
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
            this.Text = "Sound2sfxBlend2D " + Application.ProductVersion;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                copyRatherThanMove = true;
            }else
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
    }
}
