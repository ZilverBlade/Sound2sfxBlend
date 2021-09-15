using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sound2sfxBlend
{
    
    public class BlendBuilder
    {
        string CleanStringOfNonDigits_V6(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            StringBuilder sb = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];
                if (c < '0') continue;
                if (c > '9') continue;
                sb.Append(s[i]);
            }
            string cleaned = sb.ToString();
            return cleaned;
        }

        public void BuildBlend(string blendName, string soundPath, string outputFolder, string onLoadRule, string offLoadRule)
        {
            //Custom Resizable Array
            List<SFile> onlist = new List<SFile>();
            List<SFile> offlist = new List<SFile>();



            //build each line individually (partially, the art/sound/engine/ location name is still $name$)

            int arrayIndexOnL = 0;
            int arrayIndexOffL = 0;

            try
            {
                foreach (string x in System.IO.Directory.GetFiles(soundPath))
                {
                    string shN = x.Substring(x.LastIndexOf(@"\") + 1);

                    if (shN.Contains(onLoadRule))
                    {
                        int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(shN));
                        onlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                        MainWindow.progressDialogue.UpdateProgressText("Loaded sound " + onlist[arrayIndexOnL]);
                        arrayIndexOnL += 1;
                    }
                    else
                    {
                        int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(shN));
                        offlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                        MainWindow.progressDialogue.UpdateProgressText("Loaded sound " + offlist[arrayIndexOffL]);
                        arrayIndexOffL += 1;
                    }

                }
            }
            catch (Exception ex)
            {
                MainWindow.progressDialogue.UpdateProgressText("Error loading sound! " + ex.Message);

                MessageBox.Show("Failed loading sounds! You might have provided an invalid path name.", "Failed loading sounds!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            onlist.Sort(delegate (SFile x, SFile y) { return x.SoundRPM.CompareTo(y.SoundRPM); });
            offlist.Sort(delegate (SFile x, SFile y) { return x.SoundRPM.CompareTo(y.SoundRPM); });

            //build lines into a complete block
            string onloadSoundOutput = null;
            string offloadSoundOutput = null;


            try
            {
                foreach (SFile aLine in offlist)
                {
                    offloadSoundOutput += aLine;
                    offloadSoundOutput += System.Environment.NewLine;
                    offloadSoundOutput = offloadSoundOutput.Replace("$name$", blendName);
                    MainWindow.progressDialogue.UpdateProgressText("Built offload line " + aLine.ToString().Replace("$name$", blendName));
                }

                foreach (SFile aLine in onlist)
                {
                    onloadSoundOutput += aLine;
                    onloadSoundOutput += System.Environment.NewLine;
                    onloadSoundOutput = onloadSoundOutput.Replace("$name$", blendName);
                    MainWindow.progressDialogue.UpdateProgressText("Built onload line " + aLine.ToString().Replace("$name$", blendName));
                }

                offloadSoundOutput = offloadSoundOutput.Remove(offloadSoundOutput.Length - 3);
                onloadSoundOutput = onloadSoundOutput.Remove(onloadSoundOutput.Length - 3);
            }
            catch (Exception ex)
            {
                MainWindow.progressDialogue.UpdateProgressText("Error building blend! " + ex.Message);
                MessageBox.Show("Failed building blend file! You might have provided an invalid path name.", "Failed building blend file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //create json

            string templateBase = null;

            bool botherMakingASEBfolder = true;

            try
            {
                templateBase = Properties.Resources.template_sfxBlend2D.ToString();
                templateBase = templateBase.Replace("$replacementstringforoffloadsouds$", offloadSoundOutput);
                templateBase = templateBase.Replace("$replacementstringforonloadsouds$", onloadSoundOutput);
            }
            catch
            {
                botherMakingASEBfolder = false;
                MessageBox.Show("Template file missing! Try reinstalling the program if this issue persists", "Critial error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            System.IO.StreamWriter streamWriter = null;

            bool botherMovingFiles = false;
            if (botherMakingASEBfolder == false) {
                botherMovingFiles = true;

                try
                {
                    System.IO.Directory.CreateDirectory(outputFolder + "/art/sound/blends");
                    System.IO.Directory.CreateDirectory(outputFolder + "/art/sound/engine/" + blendName);
                    streamWriter = new System.IO.StreamWriter(outputFolder + "/art/sound/blends/" + blendName + ".sfxBlend2D.json");
                    streamWriter.Write(templateBase);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch
                {
                    botherMovingFiles = false;
                    MessageBox.Show("No access to path! Please choose a different folder.", "Critial error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }         


            if (botherMovingFiles==true){
                if (MainWindow.copyRatherThanMove == true)
                {
                    foreach (string x in System.IO.Directory.GetFiles(soundPath))
                    {
                        string shN = x.Substring(x.LastIndexOf(@"\") + 1);

                        System.IO.File.Copy(x, outputFolder + "/art/sound/engine/" + blendName + @"\" + shN);

                    }
                }
                else
                {
                    foreach (string x in System.IO.Directory.GetFiles(soundPath))
                    {
                        string shN = x.Substring(x.LastIndexOf(@"\") + 1);

                        System.IO.File.Move(x, outputFolder + "/art/sound/engine/" + blendName + @"\" + shN);

                    }
                }
            }

            MainWindow.progressDialogue.AllowToBeClosed();
        }

           
    }
}

