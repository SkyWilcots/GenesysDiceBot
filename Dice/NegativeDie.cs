using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.Dice
{
    public class DifficultyDie : Die
    {
        public DifficultyDie() 
        {
            faceCount = 8;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "f";
            values[2] = "ff";
            values[3] = "h";
            values[4] = "h";
            values[5] = "h";
            values[6] = "hh";
            values[7] = "fh";
        }
        public string Roll()
        {
            int result = rnd.Next(faceCount);
            return values[result];
        }

        public override void Initialize()
        {
            faceCount = 8;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "f";
            values[2] = "ff";
            values[3] = "h";
            values[4] = "h";
            values[5] = "h";
            values[6] = "hh";
            values[7] = "fh";
        }
    }

    public class SetbackDie : Die
    {
        public SetbackDie()
        {
            faceCount = 6;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "";
            values[2] = "f";
            values[3] = "f";
            values[4] = "h";
            values[5] = "h";

        }
        public string Roll()
        {
            int result = rnd.Next(faceCount);
            return values[result];
        }

        public override void Initialize()
        {
            faceCount = 6;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "";
            values[2] = "f";
            values[3] = "f";
            values[4] = "h";
            values[5] = "h";
        }
    }

    public class ChallengeDie : Die
    {
        public ChallengeDie()
        {
            faceCount = 12;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "f";
            values[2] = "f";
            values[3] = "ff";
            values[4] = "ff";
            values[5] = "h";
            values[6] = "h";
            values[7] = "fh";
            values[8] = "fh";
            values[9] = "hh";
            values[10] = "hh";
            values[11] = "d";
        }
        public string Roll()
        {
            int result = rnd.Next(faceCount);
            return values[result];
        }

        public override void Initialize()
        {
            faceCount = 12;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "f";
            values[2] = "f";
            values[3] = "ff";
            values[4] = "ff";
            values[5] = "h";
            values[6] = "h";
            values[7] = "fh";
            values[8] = "fh";
            values[9] = "hh";
            values[10] = "hh";
            values[11] = "d";
        }
    }
}
