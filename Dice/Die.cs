using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.Dice
{
    public class Die
    {
        internal static Random rnd = new Random();

        internal int faceCount { get; set; }
        internal string[] values { get; set; }
        private string _faceValue;
        internal Bitmap[] faceIcons { get; set; }

            internal string faceValue
        {
            get { return _faceValue; }
            set
            {
                if (value == "s" || 
                    value == "a" || 
                    value == "t" || 
                    value == "f" || 
                    value == "h" || 
                    value == "d" || 
                    value == "ss" || 
                    value == "sa" || 
                    value == "aa" || 
                    value == "ff" || 
                    value == "fh" || 
                    value == "hh")
                { _faceValue = value; }
                else { _faceValue = ""; }
            }
        }

        public Die()
        {
            faceCount = 6;
            values = new string[faceCount];
            values[0] = "s";
            values[1] = "a";
            values[2] = "t";
            values[3] = "f";
            values[4] = "h";
            values[5] = "d";
        }

        public string Roll()
        {
            int result = rnd.Next(faceCount);
            return values[result];
        }

        public virtual void Initialize()
        {
            faceCount = 6;
            values = new string[faceCount];
            values[0] = "s";
            values[1] = "a";
            values[2] = "t";
            values[3] = "f";
            values[4] = "h";
            values[5] = "d";
        }

    }
}
