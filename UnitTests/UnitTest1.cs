using GenesysDiceBot.Dice;
using GenesysDiceBot.RollMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;




namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PairingIconsShouldNullEachOther_1()
        {
            //Arrange
            Roller r = new Roller();
            Dictionary<char, long?> testDictionary = new Dictionary<char, long?>();
            string result = "sssaafh";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, long?> controlDictionary = new Dictionary<char, long?>
            {

                { 's', 2 },
                { 'f', 0 },
                { 'a', 1 },
                { 'h', 0 },
                { 't', 0 },
                { 'd', 0 }
            };


            //Act
            Dictionary<char, long?> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, long?> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, long?> ci in controlDictionary)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            //Assert
            CollectionAssert.AreEqual(controlDictionary, resultMap);
        }

        [TestMethod]
        public void PairingIconsShouldNullEachOther_2()
        {
            //Arrange
            Roller r = new Roller();
            Dictionary<char, long?> testDictionary = new Dictionary<char, long?>();
            string result = "fffsahhhtd";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, long?> controlDictionary = new Dictionary<char, long?>
            {

                { 's', 0 },
                { 'f', 2 },
                { 'a', 0 },
                { 'h', 2 },
                { 't', 0 },
                { 'd', 0 }
            };


            //Act
            Dictionary<char, long?> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, long?> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, long?> ci in controlDictionary)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            //Assert
            CollectionAssert.AreEqual(controlDictionary, resultMap);
        }


        [TestMethod]
        public void TriumphsShouldCountAsSuccessesAndTriumphs()
        {
            //Arrange
            Roller r = new Roller();
            Dictionary<char, long?> testDictionary = new Dictionary<char, long?>();
            string result = "sssssftahh";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, long?> controlDictionary = new Dictionary<char, long?>
            {

                { 's', 5 },
                { 'f', 0 },
                { 'a', 0 },
                { 'h', 1 },
                { 't', 1 },
                { 'd', 0 }
            };


            //Act
            Dictionary<char, long?> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, long?> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, long?> ci in controlDictionary)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            //Assert
            CollectionAssert.AreEqual(controlDictionary, resultMap);
        }

        [TestMethod]
        public void DespairsShouldCountAsFailuresAndDespairs()
        {
            //Arrange
            Roller r = new Roller();
            Dictionary<char, long?> testDictionary = new Dictionary<char, long?>();
            string result = "ffffddstaah";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, long?> controlDictionary = new Dictionary<char, long?>
            {

                { 's', 0 },
                { 'f', 4 },
                { 'a', 1 },
                { 'h', 0 },
                { 't', 0 },
                { 'd', 1 }
            };


            //Act
            Dictionary<char, long?> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, long?> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, long?> ci in controlDictionary)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            //Assert
            CollectionAssert.AreEqual(controlDictionary, resultMap);
        }

        [TestMethod]
        public void AddToContainerMethodShouldAddCorrectNumberOfDice()
        {
            //Arrange
            var r = new Roller();
            List<Die> controlContainer = new List<Die>();

            AbilityDie a1 = new AbilityDie();
            AbilityDie a2 = new AbilityDie();
            AbilityDie a3 = new AbilityDie();
            AbilityDie a4 = new AbilityDie();
            controlContainer.Add(a1);
            controlContainer.Add(a2);
            controlContainer.Add(a3);
            controlContainer.Add(a4);

            //Act
            r.AddToContainer(typeof(AbilityDie), 4);

            //Assert
            Assert.AreEqual(controlContainer.Count, r.GetDiceContainer().Count);
        }

        [TestMethod]
        public void AddToContainerShouldNotAddDiceOnZero()
        {
            //Arrange
            var r = new Roller();
            List<Die> controlContainer = new List<Die>();

            //Act
            r.AddToContainer(typeof(AbilityDie), 0);

            //Assert
            Assert.AreEqual(controlContainer.Count, 0);
        }

        [TestMethod]
        public void AddToContainerShouldIgnoreNegativeValues()
        { 
            var r = new Roller();
            List<Die> controlContainer = new List<Die>();

            //Act
            r.AddToContainer(typeof(AbilityDie), -5);

            //Assert
            Assert.AreEqual(controlContainer.Count, 0);
        }

    }
}
