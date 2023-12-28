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
            Dictionary<char,int> testDictionary = new Dictionary<char,int>();
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

                Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char,int> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, int> ci in controlDictionary)
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
            Dictionary<char, int> testDictionary = new Dictionary<char, int>();
            string result = "fffsahhhtd";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, int> controlDictionary = new Dictionary<char, int>
            {

                { 's', 0 },
                { 'f', 2 },
                { 'a', 0 },
                { 'h', 2 },
                { 't', 0 },
                { 'd', 0 }
            };


            //Act
            Dictionary<char, int> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, int> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, int> ci in controlDictionary)
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
            Dictionary<char, int> testDictionary = new Dictionary<char, int>();
            string result = "sssssftahh";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, int> controlDictionary = new Dictionary<char, int>
            {

                { 's', 5 },
                { 'f', 0 },
                { 'a', 0 },
                { 'h', 1 },
                { 't', 1 },
                { 'd', 0 }
            };


            //Act
            Dictionary<char, int> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, int> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, int> ci in controlDictionary)
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
            Dictionary<char, int> testDictionary = new Dictionary<char, int>();
            string result = "ffffddstaah";
            testDictionary = r.TallyIconTotal(result);

            Dictionary<char, int> controlDictionary = new Dictionary<char, int>
            {

                { 's', 0 },
                { 'f', 4 },
                { 'a', 1 },
                { 'h', 0 },
                { 't', 0 },
                { 'd', 1 }
            };


            //Act
            Dictionary<char, int> resultMap = r.NetIconTotal(testDictionary);

            Console.WriteLine("resultMap Dictionary:");
            foreach (KeyValuePair<char, int> ci in resultMap)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            Console.WriteLine("controlDictionary Dictionary:");
            foreach (KeyValuePair<char, int> ci in controlDictionary)
            {
                Console.WriteLine(ci.Key + ", " + ci.Value);
            }

            //Assert
            CollectionAssert.AreEqual(controlDictionary, resultMap);
        }
    }
}
