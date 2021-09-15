using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sound2sfxBlend
{
    public partial class BlendBuildingProgessDialogue : Form
    {
        public BlendBuildingProgessDialogue()
        {
            InitializeComponent();
        }

        public void BlendBuildingProgessDialogue_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = IllegalBlendNames.illegalNames.Count();
            textBox1.MaxLength = int.MaxValue;
        }

        public void UpdateProgressText(string newLog)
        {
            textBox1.Text += System.Environment.NewLine + newLog;
            textBox1.Update();
        }

        public void UpdateProgressBar(int amount)
        {
            progressBar1.Value += amount;
        }

        public void UpdateProgressBar(bool isMarquee)
        {
            if (isMarquee == true)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
            }
            
        }

        public void AllowToBeClosed()
        {
            button1.Enabled = true;
            this.Text = "Finished creating sfxBlend2D file!";
            builderProcessDialogueLbl.Text = "Finished creation";
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Maximum;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {              
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter( Application.StartupPath + @"\" + DateTime.Now.ToString().Replace(":", "-") + "_sfxblend2dexportlog.txt");
                streamWriter.Write(textBox1.Text);
                streamWriter.Flush();
                streamWriter.Close();
            }
            this.Close();
        }
    }
}
