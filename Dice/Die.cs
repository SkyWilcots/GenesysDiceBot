using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.Dice
{
    public class Die
    {
        private int faces { get; set; }
        private string[] values { get; set; }
        private string faceValue
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
            faces = 6;
            values = new string[faces];
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
            int result = rnd.Next(faces);
            return values[result];
        }
    }
}
