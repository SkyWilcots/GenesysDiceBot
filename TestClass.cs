using GenesysDiceBot.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

     /*       Console.WriteLine(bd.values[0]);
            Console.WriteLine(bd.values[1]);
            Console.WriteLine(bd.values[2]);
            Console.WriteLine(bd.values[3]);
            Console.WriteLine(bd.values[4]);
            Console.WriteLine(bd.values[5]);
            Console.WriteLine(ad.values[6]);
            Console.WriteLine(ad.values[7]);
     */
           
               // Console.WriteLine(ad.roll());
                //Console.WriteLine(pd.roll());
               // Console.WriteLine(bd.roll());


        }
    }
}
