using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sound2sfxBlend
{
    //mostly copied from microsoft's documentation xd
    public class SFile : IEquatable<SFile>, IComparable<SFile>
    {
        public string SoundName { get; set; }

        public int SoundRPM { get; set; }

        //build a working line of code
        public override string ToString()
        {
            return "[\"art/sound/engine/$name$/" + SoundName + "\", " + SoundRPM + "],";
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            SFile objAsSFile = obj as SFile;
            if (objAsSFile == null) return false;
            else return Equals(objAsSFile);
        }
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }

        // Default comparer for SFile type.
        public int CompareTo(SFile compareSFile)
        {
            // A null value means that this object is greater.
            if (compareSFile == null)
                return 1;

            else
                return this.SoundRPM.CompareTo(compareSFile.SoundRPM);
        }
        public override int GetHashCode()
        {
            return SoundRPM;
        }

        // Should also override == and != operators.
        public bool Equals(SFile other)
        {
            if (other == null) return false;
            return (this.SoundRPM.Equals(other.SoundRPM));
        }
        
    }

}
