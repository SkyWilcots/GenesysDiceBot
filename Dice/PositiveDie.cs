using System;
using System.Collections.Generic;
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
    }

    public class BoostDie : Die
    {
        public BoostDie()
        {
            faceCount = 6;
            string[] values = { "", "", "s", "sa", "aa", "a" };
        }
    }
    
    public class ProficiencyDie : Die
    {
        public ProficiencyDie()
        {
            faceCount = 12;
            string[] values = { "", "s", "s", "ss", "ss", "a", "sa", "sa", "sa", "aa", "aa", "t"};
        }
    }
}
