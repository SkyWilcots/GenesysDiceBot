using GenesysDiceBot.Dice;
using System;
using System.Collections.Generic;
using GenesysDiceBot.RollMachine;

namespace GenesysDiceBot
{
    internal class TestClass
    {

            static void Main(string[] args)
            {
                //Test Line
                Die d = new Die();

                AbilityDie ad1 = new AbilityDie();
                AbilityDie ad2 = new AbilityDie();
                AbilityDie ad3 = new AbilityDie();
                AbilityDie ad4 = new AbilityDie();

                ProficiencyDie pd = new ProficiencyDie();
                BoostDie bd = new BoostDie();

                DifficultyDie dd1 = new DifficultyDie();
                DifficultyDie dd2 = new DifficultyDie();
                DifficultyDie dd3 = new DifficultyDie();
                ChallengeDie cd = new ChallengeDie();
                SetbackDie sd = new SetbackDie();

            Roller r = new Roller();
            Dictionary<char, int> testDictionary = new Dictionary<char, int>();
            List<Die> dieList = new List<Die>();
            dieList.Add(ad1);
            dieList.Add(ad2);
            dieList.Add(ad3);
            dieList.Add(ad4);
            dieList.Add(pd);
            dieList.Add(dd1);
            dieList.Add(dd2);
            dieList.Add(dd3);
            dieList.Add(cd);
            string result = r.RollDice(dieList);
            testDictionary = r.TallyIconTotal(result);

            /*Dictionary<char, int> controlDictionary = new Dictionary<char, int>
            {
                { 's', 2 },
                { 'f', 0 },
                { 'a', 1 },
                { 'h', 0 },
                { 't', 0 },
                { 'd', 0 }
            };*/

            Console.WriteLine(result);
            Dictionary<char, int> resultMap = r.NetIconTotal(testDictionary);
            foreach (KeyValuePair<char, int> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine(r.ResultsWriteUp(resultMap));

        }
    }
}
