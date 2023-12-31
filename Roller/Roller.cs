using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenesysDiceBot.Dice;

namespace GenesysDiceBot.RollMachine
{
    public class Roller
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
               rolledString += d.Roll();
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
            if (talliedIconTotal['s'] + talliedIconTotal['t'] <= talliedIconTotal['f'] + talliedIconTotal['d'])
            {
                talliedIconTotal['f'] = talliedIconTotal['f'] + talliedIconTotal['d'] - talliedIconTotal['s'] - talliedIconTotal['t'];
                talliedIconTotal['s'] = 0;
            }
            else 
            { 
                talliedIconTotal['s'] = talliedIconTotal['s'] + talliedIconTotal['t'] - talliedIconTotal['f'] - talliedIconTotal['d'];
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
           

            return talliedIconTotal;
        }

        public string ResultsWriteUp(Dictionary<char,int> results)
        {
            string writeup = "You rolled: \n\n";
            writeup += "Successes: " + results['s'] + "\n";
            writeup += "Failures: " + results['f'] + "\n";
            writeup += "Advantages: " + results['a'] + "\n";
            writeup += "Threats: " + results['h'] + "\n";
            writeup += "Triumphs: " + results['t'] + "\n";
            writeup += "Despairs: " + results['d'];


            return writeup;



            /*int keyCounter = 0;
            string amp = "";
            string semicolon = ".";
            foreach (char key in results.Keys) 
            {
               if (results[key] <= 0) { results.Remove(key); }
            }
            if (results.Count() > 1) { amp = "and "; semicolon = ","; }
            if (results.Count() > 0) 
            {
                while (results.Count() > 1)
                {
                    semicolon = ",";
                    if (results.ContainsKey('s')) 
                    {
                        if (results['s'] == 1)
                        {
                            writeup += "1 Success" + semicolon + "\n";
                        }
                        else
                        {
                            writeup += results['s'].ToString() + " Successes" + semicolon + "\n";
                        }
                        results.Remove('s');
                        keyCounter--;

                    }

                    if (results.ContainsKey('f'))
                    {
                        if (results['f'] == 1)
                        {
                            writeup += "1 Failure" + semicolon + "\n";
                        }
                        else
                        {
                            writeup += results['f'].ToString() + " Failures" + semicolon + "\n";
                        }
                        results.Remove('f');
                        keyCounter--;
                    }

                    if (results.ContainsKey('a'))
                    {
                        if (results['a'] == 1)
                        {
                            writeup += "1 Advantage" + semicolon + "\n";
                        }
                        else
                        {
                            writeup += results['a'].ToString() + " Advantages" + semicolon + "\n";
                        }
                        results.Remove('a');
                        keyCounter--;
                    }

                    if (results.ContainsKey('h'))
                    {
                        if (results['h'] == 1)
                        {
                            writeup += "1 Threat" + semicolon + "\n";
                        }
                        else
                        {
                            writeup += results['h'].ToString() + " Threats" + semicolon + "\n";
                        }
                        results.Remove('h');
                        keyCounter--;
                    }

                    if (results.ContainsKey('t'))
                    {
                        if (results['t'] == 1)
                        {
                            writeup += "1 Triumphs" + semicolon + "\n";
                        }
                        else
                        {
                            writeup += results['t'].ToString() + " Triumphs" + semicolon + "\n";
                        }
                        results.Remove('t');
                        keyCounter--;
                    }

                }
                semicolon = ".";
                string lastIcon = "";
                foreach(char key in results.Keys)
                {
                    switch(key)
                    {
                        case 's':
                            if (results[key] == 1) { lastIcon = " Success"; }
                            else lastIcon = " Successes";
                            break;
                        case 'f':
                            if (results[key] == 1) { lastIcon = " Failure"; }
                            else lastIcon = " Failures";
                            break;
                        case 'a':
                            if (results[key] == 1) { lastIcon = " Advantage"; }
                            else lastIcon = " Advantages";
                            break;
                        case 'h':
                            if (results[key] == 1) { lastIcon = " Threat"; }
                            else lastIcon = " Threats";
                            break;
                        case 't':
                            if (results[key] == 1) { lastIcon = " Triumph"; }
                            else lastIcon = " Triumphs";
                            break;
                        case 'd':
                            if (results[key] == 1) { lastIcon = " Despair"; }
                            else lastIcon = " Despairs";
                            break;
                    }
                    writeup += amp + results[key].ToString() + lastIcon + semicolon;
                }
            }
            else
            {
                writeup = "A completely even roll!?";
            }
            return writeup;*/
        }
    }
}
