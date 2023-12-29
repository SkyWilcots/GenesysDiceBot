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

                AbilityDie ad = new AbilityDie();
                ProficiencyDie pd = new ProficiencyDie();
                BoostDie bd = new BoostDie();

                DifficultyDie dd = new DifficultyDie();
                ChallengeDie cd = new ChallengeDie();
                SetbackDie sd = new SetbackDie();

            Roller r = new Roller();
            Dictionary<char, int> testDictionary = new Dictionary<char, int>();
            string result = "sssaafh";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, int> controlDictionary = new Dictionary<char, int>
            {
                { 's', 2 },
                { 'f', 0 },
                { 'a', 1 },
                { 'h', 0 },
                { 't', 0 },
                { 'd', 0 }
            };


            //Act
            Dictionary<char, int> resultMap = r.NetIconTotal(testDictionary);
            foreach (KeyValuePair<char, int> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine(r.ResultsWriteUp(resultMap));

        }
    }
}
