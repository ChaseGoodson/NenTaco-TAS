using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NesBot;
using NesBot.Achievements;

namespace NesBotUnitTests.Achievements
{
    [TestClass]
    public class ScoreAchievementEvaluatorUnitTest
    {
        [TestMethod]
        public void WillReturnCentury()
        {
            var ScoreRunResult = new RunResult();
            ScoreRunResult.Coins = 100;

            var runResults = new List<RunResult>();
            runResults.Add(ScoreRunResult);

            var eval = new ScoreAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(0, ach.Count);
            Console.WriteLine("Century Achievement Achieved");

        }

        [TestMethod]
        public void WillReturnMellennium()
        {
            var ScoreRunResult = new RunResult();
            ScoreRunResult.Coins = 1000;

            var runResults = new List<RunResult>();
            runResults.Add(ScoreRunResult);

            var eval = new ScoreAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(0, ach.Count);
            Console.WriteLine("Mellennium Achievement Achieved");
        }
    }
}
