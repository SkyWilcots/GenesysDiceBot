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
            string[] values = { "", "f", "ff", "h", "h", "h", "hh", "fh" };
        }
    }

    public class SetbackDie : Die
    {
        public SetbackDie()
        {
            faceCount = 6;
            string[] values = { "", "", "f", "f", "h", "h" };
        }
    }

    public class ChallengeDie : Die
    {
        public ChallengeDie()
        {
            faceCount = 12;
            string[] values = { "", "f", "f", "ff", "ff", "h", "h", "fh", "fh", "hh", "hh", "d"};
        }
    }
}
