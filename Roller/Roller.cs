using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenesysDiceBot.Dice;

namespace GenesysDiceBot.Roller
{
    internal class Roller
    {
        public List<Die> diceContainer { get; set; }
        public AbilityDie abilityDie { get; }
        public ProficiencyDie proficiencyDie { get; }
        public BoostDie boostDie { get; }
        public DifficultyDie difficultyDie { get; }
        public ChallengeDie challengeDie { get; }
        public SetbackDie setbackDie { get; }

        public Roller() 
        {
            diceContainer = new List<Die>();
            abilityDie = new AbilityDie();
            proficiencyDie = new ProficiencyDie();
            boostDie = new BoostDie();
            difficultyDie = new DifficultyDie();
            challengeDie = new ChallengeDie();
            setbackDie = new SetbackDie();
            
        }

        public string RollDice(List<Die> diceContainer)
        {
            string rolledString = "";
            foreach (Die d in diceContainer)
            {
               rolledString += d.roll();
            }
            return rolledString;
        }

        public Dictionary<char,int> TallyIconTotal(string rolledString)
        {
            //string resultMessage = "You have rolled: \n";
            Dictionary<char, int> iconCounter = new Dictionary<char, int>();

            iconCounter.Add('s',0);
            iconCounter.Add('f',0);
            iconCounter.Add('a',0);
            iconCounter.Add('h',0);
            iconCounter.Add('t',0);
            iconCounter.Add('d',0);


            foreach (char c in rolledString)
            {
                    iconCounter[c] ++;
            }
            return iconCounter;
        }

        public Dictionary<char,int> NetIconTotal(Dictionary<char,int> talliedIconTotal)
        {
            if (talliedIconTotal['s'] <= talliedIconTotal['f'])
            {
                talliedIconTotal['f'] -= talliedIconTotal['s'];
                talliedIconTotal['s'] = 0;
            }
            else 
            { 
                talliedIconTotal['s'] -= talliedIconTotal['f'];
                talliedIconTotal['f'] = 0;
            }

            if (talliedIconTotal['a'] <= talliedIconTotal['h'])
            {
                talliedIconTotal['h'] -= talliedIconTotal['a'];
                talliedIconTotal['a'] = 0;
            }
            else
            {
                talliedIconTotal['a'] -= talliedIconTotal['h'];
                talliedIconTotal['h'] = 0;
            }

            if (talliedIconTotal['t'] <= talliedIconTotal['d'])
            {
                talliedIconTotal['d'] -= talliedIconTotal['t'];
                talliedIconTotal['t'] = 0;
            }
            else
            {
                talliedIconTotal['t'] -= talliedIconTotal['d'];
                talliedIconTotal['d'] = 0;
            }
            //Change this part. Triumphs and Despairs need to be counted separately as additional Successes and Failures
            //They also need to be able to keep their values for the writeup that comes later.

            return talliedIconTotal;
        }
    }
}
