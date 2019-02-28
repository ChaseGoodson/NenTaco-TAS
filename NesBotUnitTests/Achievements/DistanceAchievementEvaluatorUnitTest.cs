using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NesBot;
using NesBot.Achievements;

namespace NesBotUnitTests.Achievements
{
    [TestClass]
    public class DistanceAchievementEvaluatorUnitTest
    {
        [TestMethod]
        public void WillReturnPipeJumper()
        {
            var pipeJumpingRunResult = new RunResult();
            pipeJumpingRunResult.MaximumHorizontalDistance = 500;

            var runResults = new List<RunResult>();
            runResults.Add(pipeJumpingRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(1, ach.Count);

        }

        [TestMethod]
        public void WillReturnMarathoner()
        {
            var pipeJumpingRunResult = new RunResult();
            pipeJumpingRunResult.MaximumHorizontalDistance = 3500;

            var runResults = new List<RunResult>();
            runResults.Add(pipeJumpingRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(2, ach.Count);

        }

    }
}
