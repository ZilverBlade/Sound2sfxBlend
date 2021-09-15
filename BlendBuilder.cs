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

            System.IO.Directory.GetFiles(soundPath);

            int arrayIndexOnL = 0;
            int arrayIndexOffL = 0;
            foreach (string x in System.IO.Directory.GetFiles(soundPath))
            {
                string shN = x.Substring(x.LastIndexOf(@"\") + 1);

                if (shN.Contains(onLoadRule))
                {
                    int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(shN));
                    onlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                    Form1.progressDialogue.UpdateProgressText("Loaded sound " + onlist[arrayIndexOnL]);
                    arrayIndexOnL += 1;
                }
                else
                {
                    int onlyNrShN = Convert.ToInt32(CleanStringOfNonDigits_V6(shN));
                    offlist.Add(new SFile() { SoundName = shN, SoundRPM = onlyNrShN });
                    Form1.progressDialogue.UpdateProgressText("Loaded sound " + offlist[arrayIndexOffL]);
                    arrayIndexOffL += 1;
                }
                              
            }

            onlist.Sort(delegate (SFile x, SFile y) {return x.SoundRPM.CompareTo(y.SoundRPM);} );
            offlist.Sort(delegate (SFile x, SFile y) {return x.SoundRPM.CompareTo(y.SoundRPM); });

            //build lines into a complete block
            string onloadSoundOutput = null;
            string offloadSoundOutput = null;

            foreach (SFile aLine in offlist)
            {
                offloadSoundOutput += aLine;
                offloadSoundOutput += System.Environment.NewLine;
                offloadSoundOutput = offloadSoundOutput.Replace("$name$", blendName);
                Form1.progressDialogue.UpdateProgressText("Built offload line " + aLine.ToString().Replace("$name$", blendName));
            }
            offloadSoundOutput = offloadSoundOutput.Remove(offloadSoundOutput.Length - 3);

            foreach (SFile aLine in onlist)
            {
                onloadSoundOutput += aLine;
                onloadSoundOutput += System.Environment.NewLine;
                onloadSoundOutput = onloadSoundOutput.Replace("$name$", blendName);
                Form1.progressDialogue.UpdateProgressText("Built onload line " + aLine.ToString().Replace("$name$", blendName));
            }
            onloadSoundOutput = onloadSoundOutput.Remove(onloadSoundOutput.Length - 3);

            //create json
           
            string templateBase = Properties.Resources.template_sfxBlend2D.ToString() ;

            System.IO.Directory.CreateDirectory(outputFolder + "/art/sound/blends");
            System.IO.Directory.CreateDirectory(outputFolder + "/art/sound/engine/" + blendName);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(outputFolder + "/art/sound/blends/" + blendName + ".sfxBlend2D.json");

            templateBase = templateBase.Replace("$replacementstringforoffloadsouds$", offloadSoundOutput);
            templateBase = templateBase.Replace("$replacementstringforonloadsouds$", onloadSoundOutput);
          

            streamWriter.Write(templateBase);
            streamWriter.Flush();
            streamWriter.Close();


            
            if (Form1.copyRatherThanMove == true)
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
            

            Form1.progressDialogue.AllowToBeClosed();
        }
    }
}
