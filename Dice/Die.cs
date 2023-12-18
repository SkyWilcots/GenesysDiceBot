using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.Dice
{
    public class Die
    {
        internal int faceCount { get; set; }
        internal string[] values { get; set; }
        internal string faceValue
        {
            get { return faceValue; }
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
                { faceValue = value; }
                else { faceValue = ""; }
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

        public string roll()
        {
            Random rnd = new Random();
            int result = rnd.Next(faceCount);
            return values[result];
        }
    }
}
