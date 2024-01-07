using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.Dice
{
    public class AbilityDie : Die
    {
        public AbilityDie()
        {
            faceCount = 8;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "s";
            values[2] = "s";
            values[3] = "ss";
            values[4] = "a";
            values[5] = "a";
            values[6] = "sa";
            values[7] = "aa";


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
            values[1] = "s";
            values[2] = "s";
            values[3] = "ss";
            values[4] = "a";
            values[5] = "a";
            values[6] = "sa";
            values[7] = "aa";
        }
    }

    public class BoostDie : Die
    {
        public BoostDie()
        {
            faceCount = 6;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "";
            values[2] = "s";
            values[3] = "sa";
            values[4] = "aa";
            values[5] = "a";

        }
        public string roll()
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
            values[2] = "s";
            values[3] = "sa";
            values[4] = "aa";
            values[5] = "a";
        }
    }

    public class ProficiencyDie : Die
    {
        public ProficiencyDie()
        {
            faceCount = 12;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "s";
            values[2] = "s";
            values[3] = "ss";
            values[4] = "ss";
            values[5] = "a";
            values[6] = "sa";
            values[7] = "sa";
            values[8] = "sa";
            values[9] = "aa";
            values[10] = "aa";
            values[11] = "t";

        }
        public string roll()
        {
            int result = rnd.Next(faceCount);
            return values[result];
        }

        public override void Initialize()
        {
            faceCount = 12;
            values = new string[faceCount];
            values[0] = "";
            values[1] = "s";
            values[2] = "s";
            values[3] = "ss";
            values[4] = "ss";
            values[5] = "a";
            values[6] = "sa";
            values[7] = "sa";
            values[8] = "sa";
            values[9] = "aa";
            values[10] = "aa";
            values[11] = "t";
        }
    }
}
