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
    }
}
