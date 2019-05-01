using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NesBot;
using NesBot.Achievements;

namespace NesBotUnitTests.Achievements
{
    [TestClass]
    public class CoinAchievementEvaluatorUnitTest
    {
        [TestMethod]
        public void WillReturnPenny()
        {
            var CoinRunResult = new RunResult();
            CoinRunResult.Coins = 1;

            var runResults = new List<RunResult>();
            runResults.Add(CoinRunResult);

            var eval = new CoinAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(1, ach.Count);
            Console.WriteLine("Penny Achievement Achieved");

        }

        [TestMethod]
        public void WillReturnNickle()
        {
            var CoinRunResult = new RunResult();
            CoinRunResult.Coins = 5;

            var runResults = new List<RunResult>();
            runResults.Add(CoinRunResult);

            var eval = new CoinAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(2, ach.Count);
            Console.WriteLine("Nickel Achievement Achieved");
        }
    }
}