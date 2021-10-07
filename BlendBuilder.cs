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

        //Custom Resizable Array
        List<SFile> onlist = new List<SFile>();
        List<SFile> offlist = new List<SFile>();

        //some array stuff
        int arrayIndexOnL = 0;
        int arrayIndexOffL = 0;

        string blendName;
        string soundPath;
        string outputFolder;
        string onLoadRule;
        string offLoadRule;
        int ignore1stChar;
        int ignoreLastChar;

        string templateBase;

        bool botherMakingASEBfolder = true;
        bool botherMovingFiles = false;

        public void BuildBlend(string bName, string sPath, string outFolder, string onLRule, string offLRule, int ign1stChar, int ignlstChar)
        {
            blendName = bName;
            soundPath = sPath;
            outputFolder = outFolder;
            onLoadRule = onLRule;
            offLoadRule = offLRule;
            ignore1stChar = ign1stChar;
            ignoreLastChar = ignlstChar;

            if (MainWindow.onloadIsAlsoOffload == false)
            {
                BuildBlendWithOnloadOffload();
                FinaliseBlend();
            }
            else
            {
                BuildUnifiedBlend();
            }       
        }
        
        private void BuildBlendWithOnloadOffload()
        {
            try
            {               
                //build each line into an "array" (more like a custom list) partially, the blend name is still $name$ and load sounds                    
                foreach (string x in System.IO.Directory.GetFiles(soundPath))
                {
                    string shN = x.Substring(x.LastIndexOf(@"\") + 1);
                    if (shN.Contains(onLoadRule))
                    {
                        string cutShN = shN.Remove(shN.LastIndexOf("."));
                        cutShN = cutShN.Substring(ignore1stChar, cutShN.Length - ignore1stChar - ignoreLastChar);
                        int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(cutShN));
                        onlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                        MainWindow.progressDialogue.UpdateProgressText($"Loaded sound {onlist[arrayIndexOnL]} at rpm {onlyNrShN}");
                        arrayIndexOnL += 1;
                    }
                    else
                    {
                        string cutShN = shN.Remove(shN.LastIndexOf("."));
                        cutShN = cutShN.Substring(ignore1stChar, cutShN.Length - ignore1stChar - ignoreLastChar);
                        int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(cutShN));
                        offlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                        MainWindow.progressDialogue.UpdateProgressText($"Loaded sound {offlist[arrayIndexOffL]} at rpm {onlyNrShN}");
                        arrayIndexOffL += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.progressDialogue.UpdateProgressText("Error loading sound! " + ex.Message);
                MessageBox.Show("Failed loading sounds! You might have provided an invalid path name.", "Failed loading sounds!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinaliseBlend()
        {
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
                //for some reason this mf keeps throwing an exception even though it's in a try catch
                offloadSoundOutput = offloadSoundOutput.Remove(offloadSoundOutput.Length - 3);
                onloadSoundOutput = onloadSoundOutput.Remove(onloadSoundOutput.Length - 3);
            }
            catch (Exception ex)
            {
                MainWindow.progressDialogue.UpdateProgressText("Error building blend! " + ex.Message);
                MessageBox.Show("Failed building blend file! You might have provided an invalid path name.", "Failed building blend file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //load the built lines of code into a string and make it complete

            try
            {
                templateBase = Properties.Resources.template_sfxBlend2D.ToString();
                templateBase = templateBase.Replace("$replacementstringforoffloadsounds$", offloadSoundOutput);
                templateBase = templateBase.Replace("$replacementstringforonloadsounds$", onloadSoundOutput);
            }
            catch
            {
                botherMakingASEBfolder = false;
                MessageBox.Show("Template file missing! Try reinstalling the program if this issue persists", "Critial error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FinishBlend(templateBase);
        }

        private void FinishBlend(string builtBlend)
        {
            //create json
            System.IO.StreamWriter streamWriter = null;
            if (botherMakingASEBfolder == true)
            {
                botherMovingFiles = true;
                try
                {
                    System.IO.Directory.CreateDirectory(outputFolder + "/art/sound/blends");
                    System.IO.Directory.CreateDirectory(outputFolder + "/art/sound/engine/" + blendName);
                    streamWriter = new System.IO.StreamWriter(outputFolder + "/art/sound/blends/" + blendName + ".sfxBlend2D.json");
                    streamWriter.Write(builtBlend);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch
                {
                    botherMovingFiles = false;
                    MessageBox.Show("No access to path! Please choose a different folder.", "Critial error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //move or copy (depending on the user's choice) sound files over to the new location
            if (botherMovingFiles == true)
            {
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
            MainWindow.progressDialogue.exportedPath = outputFolder + @"\art";
            MainWindow.progressDialogue.UpdateProgressText("Successfully created sound blend \"" + blendName + "\" in "+ outputFolder);
            MainWindow.progressDialogue.AllowToBeClosed();
        }

        private void BuildUnifiedBlend()
        {
            try
            {
                foreach (string x in System.IO.Directory.GetFiles(soundPath))
                {
                    string shN = x.Substring(x.LastIndexOf(@"\") + 1);
                    string cutShN = shN.Remove(shN.LastIndexOf("."));
                    cutShN = cutShN.Substring(ignore1stChar, cutShN.Length - ignore1stChar - ignoreLastChar);
                    int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(cutShN));
                    onlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                    MainWindow.progressDialogue.UpdateProgressText($"Loaded sound {onlist[arrayIndexOnL]} at rpm {onlyNrShN}");
                    arrayIndexOnL += 1;
                }
            }
            catch (Exception ex)
            {
                MainWindow.progressDialogue.UpdateProgressText("Error loading sound! " + ex.Message);
                MessageBox.Show("Failed loading sounds! You might have provided an invalid path name.", "Failed loading sounds!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            onlist.Sort(delegate (SFile x, SFile y) { return x.SoundRPM.CompareTo(y.SoundRPM); });

            //build lines into a complete block
            string onloadSoundOutput = null;
            try
            {

                foreach (SFile aLine in onlist)
                {
                    onloadSoundOutput += aLine;
                    onloadSoundOutput += System.Environment.NewLine;
                    onloadSoundOutput = onloadSoundOutput.Replace("$name$", blendName);
                    MainWindow.progressDialogue.UpdateProgressText("Built onload line " + aLine.ToString().Replace("$name$", blendName));
                }
                //for some reason this mf keeps throwing an exception even though it's in a try catch              
                onloadSoundOutput = onloadSoundOutput.Remove(onloadSoundOutput.Length - 3);
            }
            catch (Exception ex)
            {
                MainWindow.progressDialogue.UpdateProgressText("Error building blend! " + ex.Message);
                MessageBox.Show("Failed building blend file! You might have provided an invalid path name.", "Failed building blend file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //load the built lines of code into a string and make it complete
            string templateBase = null;
            try
            {
                templateBase = Properties.Resources.template_sfxBlend2D.ToString();

                templateBase = templateBase.Replace("$replacementstringforonloadsounds$", onloadSoundOutput);
                templateBase = templateBase.Replace("$replacementstringforoffloadsounds$", onloadSoundOutput);
            }
            catch
            {
                botherMakingASEBfolder = false;
                MessageBox.Show("Template file missing! Try reinstalling the program if this issue persists", "Critial error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FinishBlend(templateBase);
        }
    }
}

